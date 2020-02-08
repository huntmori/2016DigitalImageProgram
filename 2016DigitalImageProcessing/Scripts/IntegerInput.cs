using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016DigitalImageProcessing.Scripts
{
    public partial class IntegerInput : Form
    {
        public int value = 0;
        public IntegerInput()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(textBox1.Text, out value);
            }
            catch(Exception ex)
            {
                textBox1.Text = "";
                value = 0;
                Console.WriteLine(ex.ToString());
                AlertUtil.AlertIntegerParseErr();
            }
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
