using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016DigitalImageProcessing
{
    public partial class LineInputBox : Form
    {
        public  int xStart;
        public int yStart;
        public int xEnd;
        public int yEnd;
        public int value;

        public LineInputBox()
        {
            InitializeComponent();
            xStart = 0;
            xEnd = 0;
            yStart = 0;
            yEnd = 0;
            value = 0;
        }

        private int check_value(object sender, EventArgs e, ref int num, TextBox box)
        {
            num = 0;
            try
            {
                num = Int32.Parse(box.Text);
            }
            catch(Exception ex)
            {
                box.Text = "";
                num = 0;
                AlertUtil.AlertIntegerParseErr();
                Console.WriteLine(ex.ToString());

            }
            return num;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref xStart, textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref yStart, textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref xEnd, textBox3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref yEnd, textBox4);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref value, textBox5);
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
