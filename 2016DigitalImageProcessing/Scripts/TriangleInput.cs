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
    public partial class TriangleInput : Form
    {
        public int point1_x;    public int point1_y;
        public int point2_x;    public int point2_y;
        public int point3_x;    public int point3_y;

        public TriangleInput()
        {
            InitializeComponent();
            point1_x = 0;            point1_y = 0;
            point2_x = 0;            point2_y = 0;
            point3_x = 0;            point3_y = 0;
        }

        private int check_value(ref int num, TextBox target)
        {
            num = 0;
            try
            {
                num = Int32.Parse(target.Text);
            }
            catch (Exception ex)
            {
                target.Text = "";
                Console.WriteLine(ex.ToString());
                AlertUtil.AlertIntegerParseErr();
            }

            return num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Point1_X_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point1_x, Point1_X);
        }

        private void Point1_Y_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point1_y, Point1_Y);
        }

        private void Point2_X_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point2_x, Point2_X);
        }

        private void Point2_Y_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point2_y, Point2_Y);
        }

        private void Point3_X_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point3_x, Point3_X);
        }

        private void Point3_Y_TextChanged(object sender, EventArgs e)
        {
            check_value(ref point3_y, Point3_Y);
        }
    }
}
