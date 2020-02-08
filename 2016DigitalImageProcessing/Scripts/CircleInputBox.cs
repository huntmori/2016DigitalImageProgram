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
    public class AlertUtil
    {
        public static void AlertIntegerParseErr()
        {
            MessageBox.Show("오류:올바른 정수를 입력해주세요.");
        }
    }
    public partial class CircleInputBox : Form
    {
        public int x;
        public int y;
        public int r;
        public int value;

        public CircleInputBox()
        {
            InitializeComponent();
            x = 0;y = 0;r = 0;value = 0;
        }

        private int check_value(Object sender, EventArgs e,
                                ref int num, TextBox target)
        {
            num = 0;

            try
            {
                num = Int32.Parse(target.Text);
            }
            catch(Exception ex)
            {
                target.Text = "";
                num = 0;
                AlertUtil.AlertIntegerParseErr();
                Console.WriteLine(ex.ToString());

            }
            return num;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref x, textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref y, textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref r, textBox3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            check_value(sender, e, ref value, textBox4);
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
