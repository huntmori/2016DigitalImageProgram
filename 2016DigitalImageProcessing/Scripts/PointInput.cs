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
    public partial class PointInput : Form
    {
        public int x;
        public int y;

        public PointInput()
        {
            InitializeComponent();
            x = 0;
            y = 0;

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private int check_value(ref int num, TextBox target)
        {
            num = 0;
            try
            {
                num = Int32.Parse(target.Text);
            }
            catch(Exception ex)
            {
                target.Text = "";
                Console.WriteLine(ex.ToString());
                AlertUtil.AlertIntegerParseErr();
            }

            return num;
        }

        private void InputX_TextChanged(object sender, EventArgs e)
        {
            check_value(ref x, InputX);
        }

        private void InputY_TextChanged(object sender, EventArgs e)
        {
            check_value(ref y, InputY);
        }
    }
}
