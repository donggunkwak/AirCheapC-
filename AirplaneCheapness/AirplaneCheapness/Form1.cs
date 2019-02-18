using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AirplaneCheapness
{
    public partial class Form1 : Form
    {
        public static int start = 0;
        public static int end = 0;
        public static int[,]a;
        public static char stemp;
        public static char etemp;
        public static int wtemp;
        public static int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n = 5;
            a = new int[n+1,n+1];
            for(int i = 1;i<=n;i++)
            {
                for(int j = 1;j<=n;j++)
                {
                    if (i == j)
                        continue;
                    a[i, j] = 1000000;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //start and end
            int[,] d = new int[n + 1, n + 1];
            for(int i =1;i<=n;i++)
            {
                for(int j =1;j<=n;j++)
                {
                    d[i, j] = a[i, j];
                }
            }
            for (int k = 1; k <=n; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (d[i,k] + d[k,j] < d[i,j])
                            d[i,j] = d[i,k] + d[k,j];
                    }
                }
            }
            if (d[start, end] != 1000000)
                label3.Text = "The Minimum Price is: " + d[start, end];
            else
                label3.Text = "Cannot reach this destination";

        }

        private void Start_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            string theText = objTextBox.Text;
            char[] temp = theText.ToCharArray();
            start = temp[0] - 'A' + 1;
        }

        private void End_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            string theText = objTextBox.Text;
            char[] temp = theText.ToCharArray();
            end = temp[0] - 'A' + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new Flight
            string theText = textBox1.Text;
            String[] temp = theText.Split(' ');
            stemp = ' ';
            etemp = ' ';
            wtemp = ' ';
            stemp = temp[0].ToCharArray()[0];
            etemp = temp[1].ToCharArray()[0];
            wtemp = Int32.Parse(temp[2]);
            a[(int)(stemp - 'A' + 1), (int)(etemp - 'A' + 1)] = wtemp;
            a[(int)(etemp - 'A' + 1), (int)(stemp - 'A' + 1)] = wtemp;
            String text = "{";
            for (int i =1;i<=n;i++)
            {
                for(int j =1;j<=n;j++)
                {
                    if (a[i, j] == 1000000)
                    {
                        text += "0, ";
                        continue;
                    }
                    text += a[i, j]+", "; 
                }
                text += "}, {";
            }
            label5.Text = text.Substring(0,text.Length-3);
            textBox1.Text = "";
        }

    }
}
