using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;


namespace _2016DigitalImageProcessing
{
    public partial class Form1 : Form
    {
        String[] imageNames = null;
        DCT DctObject = null;

        //Form1.Designer.cs의 InitailizeComponent를 호출(UI컴포넌트 생성)
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenedFileListSelect(object sender, EventArgs e)
        {

            if (OpenedFileList.SelectedIndex >= 0)
            {
                string filename = OpenedFileList.SelectedItem as string;
                MainPictureBox.Image = new Bitmap(filename);
            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 86, 372, 20);
            buttonOk.SetBounds(228, 122, 75, 23);
            buttonCancel.SetBounds(309, 122, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void ClearAllButtonClick(object sender, EventArgs e)
        {
            if (MainPictureBox.Image != null)
            {
                MainPictureBox.Image.Dispose();
                MainPictureBox.Image = null;
            }
            if(resultPictureBox.Image != null)
            {
                resultPictureBox.Image.Dispose();
                resultPictureBox.Image = null;
            }
            if (OpenedFileList.Items != null)
            {
                OpenedFileList.Items.Clear();
                OpenedFileList.Text = "";
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 멀티파일
                if (openFileDialog1.FileNames.Count() > 1)
                {
                    imageNames = openFileDialog1.FileNames;
                }
                else // 단일파일
                {
                    imageNames = new string[1];
                    imageNames[0] = openFileDialog1.FileName;
                }

                // 콤보박스에 경로들을 추가
                for (int i = 0; i < imageNames.Count(); i++)
                {
                    OpenedFileList.Items.Add(imageNames[i]);
                }


                OpenedFileList.SelectedIndex = 0;
                MainPictureBox.Image = new Bitmap(OpenedFileList.SelectedItem as string);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void multiSaveSaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();


            string path = dialog.SelectedPath;

            string fileFirstName = "";
            string value = "untitled";
            string prompt = "Please type FileFirstName\n(All save now Opened Files)";

            if (InputBox("FileFirstName", prompt, ref value) == DialogResult.OK)
                fileFirstName = value;
            else
                return;

            
            //파일 이름+번호를 한 뒤 세이브
            for (int i = 0; i < OpenedFileList.Items.Count; i++)
            {
                string filePathName = path + "\\" + fileFirstName;

                MainPictureBox.Image = new Bitmap(OpenedFileList.Items[i] as string);
                MainPictureBox.Image.Save(filePathName + i + ".jpg", ImageFormat.Jpeg);

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Images | *.png;*.bmp;*.jpg";
            ImageFormat format;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = System.IO.Path.GetExtension(saveFileDialog1.FileName);

                switch (filename)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    default:
                        format = ImageFormat.Png;
                        break;
                }
                MainPictureBox.Image.Save(saveFileDialog1.FileName, format);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image newImage = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            Graphics graphics = Graphics.FromImage(newImage);
            graphics.Clear(BackColor);

            MainPictureBox.Image = new Bitmap(newImage);
            DrawGrid();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineInputBox input = new LineInputBox();
            input.ShowDialog();
            DDALineDrawing(input.xStart, input.yStart, input.xEnd, input.yEnd, input.value);
            
            //input
        }

        private void bresenhamMidpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineInputBox input = new LineInputBox();
            input.ShowDialog();
            MidpointLine(input.xStart, input.yStart, input.xEnd, input.yEnd, input.value);
        }

        // 김 종현 20084262
        private static void Swap<T>(ref T leftValue, ref T rightValue)
        { T temp; temp = leftValue; leftValue = rightValue; rightValue = temp; }
        private void MidpointLine(int xStart, int yStart, int xEnd, int yEnd, int value)
        {
            //DrawGrid();
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            Color valueColor = Color.FromArgb(value, value, value);
            int dx, dy, d, x, y;

            bool change = Math.Abs(yEnd - yStart) > Math.Abs(xEnd - xStart);

            if (change)
            {
                Swap<int>(ref xStart, ref yStart);
                Swap<int>(ref xEnd, ref yEnd);
            }
            if (xStart > xEnd)
            {
                Swap<int>(ref xStart, ref xEnd);
                Swap<int>(ref yStart, ref yEnd);
            }

            dx = xEnd - xStart;
            dy = Math.Abs(yEnd - yStart);
            d = dx / 2;
            int yIncreament = (yStart < yEnd) ? 1 : -1;

            x = xStart;
            y = yStart;

            for (; x < xEnd; ++x)
            {
                d -= dy;
                if (change)
                    tempBitmap.SetPixel(y, x, valueColor);
                else
                    tempBitmap.SetPixel(x, y, valueColor);

                if (d < 0)
                {
                    y += yIncreament;
                    d += dx;
                }
            }

            MainPictureBox.Image = tempBitmap;
        }
        private void dDALineDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineInputBox input = new LineInputBox();
            input.ShowDialog();
            DDALineDrawing(input.xStart, input.yStart, input.xEnd, input.yEnd, input.value);
        }
        private void DDALineDrawing(int xStart, int yStart, int xEnd, int yEnd, int value)
        {
            //DrawGrid();
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            Color color = Color.FromArgb(value, value, value);

            int dx = xEnd - xStart;
            int dy = yEnd - yStart;

            tempBitmap.SetPixel(xStart, yStart, color);

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                int x = xStart;
                double y = yStart;

                int xIncreament = dx > 0 ? 1 : -1;
                double yIncreament = (double)dy / dx * xIncreament;

                while (x != xEnd)
                {
                    x += xIncreament;
                    y += yIncreament;

                    tempBitmap.SetPixel(x, (int)Math.Floor(y + 0.5f), color);
                }
            }
            else
            {
                int y = yStart;
                int yIncreament = dy > 0 ? 1 : -1;
                double x = xStart;
                double xIncreament = (double)dx / dy * yIncreament;

                while (y != yEnd)
                {
                    x += xIncreament;
                    y += yIncreament;

                    tempBitmap.SetPixel((int)Math.Floor(x + 0.5f), y, color);
                }
            }
            MainPictureBox.Image = tempBitmap;
        }
        private void bresenhamMidpointCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircleInputBox input = new CircleInputBox();
            input.ShowDialog();
            BresenhamMidPointCircleDrawing(input.x, input.y, input.r, input.value);
                 
        }
        private void DrawGrid()
        {
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;

            for(int x=0; x<tempBitmap.Width; x++)
            {
                for(int y=0; y<tempBitmap.Height; y++)
                {
                    if(x%50==0)
                    {
                        tempBitmap.SetPixel(x, y, Color.FromArgb(190, 190, 190));
                    }
                    if(y%50==0)
                        tempBitmap.SetPixel(x, y, Color.FromArgb(190, 190, 190));
                }
            }
        }
        private void BresenhamMidPointCircleDrawing(int x, int y, int radius, int value)
        {
            DrawGrid();
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            Color color = Color.FromArgb(value, value, value);
            float d;

            int xpos=0;
            int ypos = radius;

            d = 5.0f / 4 - radius;

            _8WaySymmetryPixel(x, y, xpos, ypos, color);

            while (ypos >= xpos)
            {
                _8WaySymmetryPixel(x, y, ypos, xpos, color);
                if (d<0)
                {
                    d += xpos * 2.0f + 1;
                    xpos++;
                }
                else
                {
                    d += (xpos - ypos) * 2.0f + 1;
                    xpos++;
                    ypos--;
                }
                
            }
            
            MainPictureBox.Image = tempBitmap;
        }
        private void _8WaySymmetryPixel(int circleX, int circleY, int x, int y, Color color)
        {
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            tempBitmap.SetPixel(circleX + x, circleY + y,   color);
            tempBitmap.SetPixel(circleX + x, circleY - y,   color);
            tempBitmap.SetPixel(circleX - x, circleY + y,   color);
            tempBitmap.SetPixel(circleX - x, circleY - y,   color);
            tempBitmap.SetPixel(circleX + y, circleY + x,   color);
            tempBitmap.SetPixel(circleX + y, circleY - x,   color);
            tempBitmap.SetPixel(circleX - y, circleY + x,   color);
            tempBitmap.SetPixel(circleX - y, circleY - x,   color);
            MainPictureBox.Image=tempBitmap;
        }

        private void lowpassFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterMask mask = new FilterMask(3, 1, "Lowpass", MainPictureBox.Image as Bitmap);
            mask.AdjustFilter();

            resultPictureBox.Image = mask.ReturnResult();
        }
        private void highpassFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FilterMask mask = new FilterMask(3, 1, "Highpass", MainPictureBox.Image as Bitmap);
            int[][] temp = new int[3][];

            for (int i = 0; i < 3; i++)
                temp[i] = new int[3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    temp[i][j] = -1;
            temp[1][1] = 12;
            mask.SetMask(temp);
            mask.nomalize = 1;

            mask.AdjustFilter();

            resultPictureBox.Image = mask.ReturnResult();
        }
        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterMask mask = new FilterMask(9, 0, "Median", MainPictureBox.Image as Bitmap);
            mask.AdjustFilter();

            resultPictureBox.Image = mask.ReturnResult();
        }
        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FilterMask mask = new FilterMask(5, 1, "Lowpass",MainPictureBox.Image as Bitmap);
            FilterMask mask = new FilterMask(3, 0, "Median", MainPictureBox.Image as Bitmap);

            //FilterMask mask = new FilterMask(5, 1, "Highpass",MainPictureBox.Image as Bitmap);
            int[][] temp = new int[3][];

            for (int i = 0; i < 3; i++)
                temp[i] = new int[3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    temp[i][j] = -1;
            temp[1][1] = 8;
            mask.SetMask(temp);
            mask.nomalize = 9;
            mask.AdjustFilter();

            resultPictureBox.Image = mask.ReturnResult();

        }

        private void LowPassFilter(int filterSize, int filterLevel)
        {

        }
        public void GenerateSaltAndPepper()
        {
            Bitmap temp = MainPictureBox.Image as Bitmap;

            Random xRandom = new Random();
            Random valueRandom = new Random();

            int division = xRandom.Next(2, 300);
            int value = valueRandom.Next(0, 2);


            for(int i=0; i<temp.Height;i++)
            {
                for(int j=9; j<temp.Width-9; j++)
                {
                    if (j % division == 0 )
                    {
                        if (value == 1)
                            temp.SetPixel(j, i,Color.FromArgb(255,255,255));
                        else
                            temp.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                        division = xRandom.Next(2, 300);
                        value = valueRandom.Next(0, 2);
                    }
                }
            }

            resultPictureBox.Image = temp;

        }
        public int ClampingPixel(int x)
        {
            if (x > 255)
                x = 255;
            if (x < 0)
                x = 0;
            return x;
        }
        public Color ClampingPixel(Color c)
        {
            int r= ClampingPixel(c.R);
            int g = ClampingPixel(c.G);
            int b = ClampingPixel(c.B);

            return Color.FromArgb(r, g, b);
        }
        public class ArithmethicalOperation
        {
            Bitmap Image;
            Bitmap OperationImage;
            Bitmap Result;

            string operation;

            public int ClampingPixel(int x)
            {
                if (x > 255)
                    x = 255;
                if (x < 0)
                    x = 0;
                return x;
            }
            public Color ClampingPixel(Color c)
            {
                int r = ClampingPixel(c.R);
                int g = ClampingPixel(c.G);
                int b = ClampingPixel(c.B);

                return Color.FromArgb(r, g, b);
            }
            public ArithmethicalOperation(Image input, Image input2, String op)
            {
                this.Image = input.Clone() as Bitmap;
                this.OperationImage = input2.Clone() as Bitmap;
                this.operation = op;

                Result = null;
            }

            public Bitmap Minus(Bitmap input1, Bitmap input2)
            {
                Bitmap result = new Bitmap(input1.Width, input1.Height);

                for(int y=0; y<result.Height; y++)
                {
                    for(int x=0; x<result.Width; x++)
                    {
                        Color input1XY = input1.GetPixel(x, y);
                        Color input2XY = input2.GetPixel(x, y);

                        int r = ClampingPixel(input1XY.R - input2XY.R);
                        int g = ClampingPixel(input1XY.G - input2XY.G);
                        int b = ClampingPixel(input1XY.B - input2XY.B);

                        result.SetPixel(x, y, Color.FromArgb(r,g, b)); 
                    }
                }
                return result;
            }

            public Bitmap Minus()
            {
                Result = Minus(Image, OperationImage);

                return Result;
            }
        }
        public class FilterMask
        {
            int filterSize;
            int filterLevel;

            bool isLowPass;
            bool isHighPass;
            bool isMedian;

            Bitmap image;
            Bitmap Result;

            public int nomalize;

            int[][] mask;
            //PixelFormat[][] filter;
            public Bitmap ReturnResult()
            {
                return Result.Clone() as Bitmap;
            }
            public FilterMask(int size, int level, string s,  Bitmap image)
            {
                this.filterSize = size;
                this.filterLevel = level;
                this.image = image.Clone() as Bitmap;

                mask = new int[filterSize][];

                int division = filterSize * filterSize;

                if (s.Equals("Lowpass"))
                {
                    isLowPass = true;
                    isHighPass = false;
                    isMedian = false;
                }
                else if (s.Equals("Highpass"))
                {
                    isLowPass = false;
                    isHighPass = true;
                    isMedian = false;
                }
                else if (s.Equals("Median"))
                {
                    isLowPass = false;
                    isHighPass = false;
                    isMedian = true;
                }

                for (int i = 0; i < mask.Count(); i++)
                    mask[i] = new int[filterSize];

                int x = (filterSize / 2);
                int y = (filterSize / 2);

                int LevelValue = level / (size * size);
                nomalize = 0;

                //필터 마스크 초기화
                for(int i = 0; i <mask.Count(); i++)
                {
                    for(int j=0; j< mask[i].Count(); j++)
                    {
                        if (isLowPass)
                            mask[i][j] = 1;
                        else if (isHighPass)
                            mask[i][j] = -1;
                        nomalize += mask[i][j];
                    }
                }

                mask[x][y] = LevelValue;
                if (isLowPass)
                    nomalize += LevelValue;
                else if (isHighPass)
                    nomalize += 1;
                System.Console.WriteLine(mask[x][y]);

                
                Result = image.Clone() as Bitmap;
            }

            //클래스 외부에서 직접 슬라이드/계수를 전달하는 경우 사용
            public void SetMask(int[][] m)
            {
                this.mask = m.Clone() as int[][];
                filterSize = mask.Count();
                int sum = 0;
                for (int i = 0; i < mask.Count(); i++)
                    for (int j = 0; j < mask[i].Count(); j++)
                        sum += mask[i][j];

                nomalize = sum;

            }

            public Bitmap AdjustFilter()
            {
                for(int y=0; y<image.Height-filterSize; y++)
                {
                    for(int x=0; x<image.Width-filterSize; x++)
                    {
                        if (isLowPass)
                            AdjustLowPassFilter(x, y);
                        else if (isHighPass)
                            AdjustHighPassFilter(x, y);
                        else if (isMedian)
                            AdjustMedianFilterWidthSide(x, y);
                    }
                }

                if(isMedian)
                {
                    for(int y=0; y<image.Height-filterSize; y++)
                    {
                        for(int x=0; x<image.Width-filterSize; x++)
                        {
                            AdjustMedianFilterHeightSide(x, y);
                        }
                    }
                }
                return Result;
            }

            public void SettingMask()
            {
                mask = new int[filterSize][];

                int division = filterSize * filterSize;

                for(int i=0; i < mask.Count(); i++)
                    mask[i] = new int[filterSize];

            }
            
            public void AdjustLowPassFilter(int x, int y)
            {
                int targetX = x + (filterSize / 2);
                int targetY = y + (filterSize / 2);

                float[][] tempMask = mask.Clone() as float[][];

                int sumR = 0;
                int sumG = 0;
                int sumB = 0;
                for(int i=0; i<mask.Count(); i++)
                {
                    for(int j=0; j<mask[i].Count(); j++)
                    {
                        sumR += (int)(image.GetPixel(x + j, y + i).R * mask[j][i]);
                        sumG += (int)(image.GetPixel(x + j, y + i).G * mask[j][i]);
                        sumB += (int)(image.GetPixel(x + j, y + i).B * mask[j][i]);
                    }
                }
                sumR = RGBLimit(sumR/nomalize);
                sumG = RGBLimit(sumG/nomalize);
                sumB = RGBLimit(sumB/nomalize);

                Result.SetPixel(targetX, targetY, Color.FromArgb(sumR, sumG, sumB));
            }

            public void AdjustMedianFilterWidthSide(int x, int y)
            {
                //initializegp
                int targetX= x + (int)(filterSize / 2 );
                int targetY=y;

                List<int> sortingValuesR = new List<int>();
                List<int> sortingValuesG = new List<int>();
                List<int> sortingValuesB = new List<int>();
                
                for (int i=0; i<filterSize; i++)
                {
                    sortingValuesR.Add(image.GetPixel(x + i, y).R);
                    sortingValuesG.Add(image.GetPixel(x + i, y).G);
                    sortingValuesB.Add(image.GetPixel(x + i, y).B);
                }
                sortingValuesR.Sort();
                sortingValuesG.Sort();
                sortingValuesB.Sort();

                int median = filterSize / 2;
                Color color = Color.FromArgb(
                                                sortingValuesR[median],
                                                sortingValuesG[median],
                                                sortingValuesB[median]);

                Result.SetPixel(targetX, targetY, color);
            }
            public void AdjustMedianFilterHeightSide(int x, int y)
            {
                //initialize
                int targetX = x;
                int targetY = y+(int)(filterSize / 2);


                List<int> sortingValuesR = new List<int>();
                List<int> sortingValuesG = new List<int>();
                List<int> sortingValuesB = new List<int>();

                for (int i = 0; i < filterSize; i++)
                {
                    sortingValuesR.Add(image.GetPixel(x, y+i).R);
                    sortingValuesG.Add(image.GetPixel(x, y+i).G);
                    sortingValuesB.Add(image.GetPixel(x, y+i).B);
                }
                sortingValuesR.Sort();
                sortingValuesG.Sort();
                sortingValuesB.Sort();

                int median = filterSize / 2;
                Color color = Color.FromArgb(
                                                (int)sortingValuesR[median],
                                                (int)sortingValuesG[median],
                                                (int)sortingValuesB[median]);

                Result.SetPixel(targetX, targetY, color);
            }

            public int RGBLimit(int x)
            {
                if (x > 255)
                    x = 255;
                else if (x < 0)
                    x = 0;

                return x;
            }
          
            public void AdjustHighPassFilter(int x, int y)
            {
                int targetX = x + (filterSize / 2);
                int targetY = y + (filterSize / 2);

                //float[][] tempMask = mask.Clone() as float[][];

                int sumR = 0;
                int sumG = 0;
                int sumB = 0;
                for (int i = 0; i < mask.Count(); i++)
                {
                    for (int j = 0; j < mask[i].Count(); j++)
                    {
                        sumR += (int)(image.GetPixel(x + j, y + i).R * mask[j][i]);
                        sumG += (int)(image.GetPixel(x + j, y + i).G * mask[j][i]);
                        sumB += (int)(image.GetPixel(x + j, y + i).B * mask[j][i]);
                    }
                }
                sumR = RGBLimit(sumR / nomalize);
                sumG = RGBLimit(sumG / nomalize);
                sumB = RGBLimit(sumB / nomalize);

                Result.SetPixel(targetX, targetY, Color.FromArgb(sumR, sumG, sumB));
            }
        }

        private void resultPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void resultAdjustButton_Click(object sender, EventArgs e)
        {
            if(resultPictureBox.Image!= null)
            {
                MainPictureBox.Image = resultPictureBox.Image.Clone() as Image;
                //resultPictureBox.Image.Dispose();
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = MainPictureBox.Image.Width;
            int height = MainPictureBox.Image.Height;

            Bitmap gray = MainPictureBox.Image as Bitmap;
            for (int i = 0; i < height; i++)
            {
                for(int j=0; j< width; j++)
                {
                    int avg = gray.GetPixel(j, i).R + gray.GetPixel(j, i).G + gray.GetPixel(j, i).B;
                    avg = avg / 3;
                    gray.SetPixel(j, i, Color.FromArgb(avg, avg, avg));
                }
            }

            resultPictureBox.Image = gray.Clone() as Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MainPictureBox.Image != null)
            {
                resultPictureBox.Image = MainPictureBox.Image.Clone()as Image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainPictureBox.Image != null)
            {
                MainPictureBox.Image = null;
                //MainPictureBox.Image.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resultPictureBox.Image != null)
            {
                resultPictureBox.Image = null;
                //resultPictureBox.Image.Dispose();
            }
        }

        private void negativeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultPictureBox.Image = MainPictureBox.Image.Clone() as Image;
            Bitmap temp = resultPictureBox.Image.Clone() as Bitmap;

            for (int y = 0;  y < temp.Height; y++)
            {
                for(int x=0; x< temp.Width; x++)
                {
                    Color color = temp.GetPixel(x, y);

                    int red = 255 - color.R;
                    int green = 255 - color.G;
                    int blue = 255 - color.B;

                    color = Color.FromArgb(red, green, blue);
                    temp.SetPixel(x, y, color);
                }
            }

            resultPictureBox.Image = temp.Clone() as Image;
            temp.Dispose();
        }

        private void minusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image operation;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                operation = new Bitmap(openFileDialog1.FileName);

                ArithmethicalOperation op = new ArithmethicalOperation(MainPictureBox.Image,
                                                                   operation, "Minus");
                resultPictureBox.Image = op.Minus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (resultPictureBox.Image != null)
            {
                resultPictureBox.Image = null;
                //resultPictureBox.Image.Dispose();
            }
        }

        private void generatingSaltAndPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateSaltAndPepper();
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 고주파강조ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FilterMask mask = new FilterMask(5, 1, "Lowpass",MainPictureBox.Image as Bitmap);
            //FilterMask mask = new FilterMask(9, 0, "Median", MainPictureBox.Image as Bitmap);

            FilterMask mask = new FilterMask(3, 17, "Lowpass", MainPictureBox.Image as Bitmap);
            int[][] temp = new int[3][];

            for (int i = 0; i < 3; i++)
                temp[i] = new int[3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    temp[i][j] = -1;
            temp[1][1] = 17;
            mask.SetMask(temp);
            mask.nomalize = 9;

            mask.AdjustFilter();

            resultPictureBox.Image = mask.ReturnResult();
        }

        private void upDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MainPictureBox.Image!= null)
            {
                Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
                Bitmap result = new Bitmap(temp.Width, temp.Height);

                int peddingY = result.Height-1;
                for(int y=0; y<result.Height; y++)
                {
                    for(int x=0; x<result.Width;x++)
                    {
                        result.SetPixel(x, peddingY - y, temp.GetPixel(x, y));
                    }
                }
                resultPictureBox.Image = result;
            }
        }

        private void leftRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainPictureBox.Image != null)
            {
                Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
                Bitmap result = new Bitmap(temp.Width, temp.Height);

                int peddingX = result.Width - 1;
                for (int y = 0; y < result.Height; y++)
                {
                    for (int x = 0; x < result.Width; x++)
                    {
                        result.SetPixel(peddingX - x, y, temp.GetPixel(x, y));
                    }
                }

                resultPictureBox.Image = result;
            }
        }

        private void circleNRectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircleInputBox input = new CircleInputBox();
            input.ShowDialog();
            int centerX = input.x;
            int centerY = input.y;
            int radius = input.r;
            int value = input.value;

            //1st Draw Circle
               DrawCircleFill(centerX, centerY, radius, value);
            //2nd Fill the Circle

            //3rd find Rect Above Point
            int rectX = 0;
            int rectY = 0;
            DetectRectInCircle(centerX, centerY, radius, ref rectX, ref rectY);
            //4th Draw Rect && //5th Fill the Rect
            int rectEdge = (int)(2 * radius / Math.Sqrt(2));
            DrawRect(rectX, rectY, rectEdge, rectEdge, 0, Color.FromName("Blue"));
            
        }

        private void DetectRectInCircle(int centerX, int centerY, int radius,ref int rectx,ref int recty)
        {
            //DrawGrid();
            //Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            //Color color = Color.FromArgb(value, value, value);
            float d;

            int xpos = 0;
            int ypos = radius;

            d = 5.0f / 4 - radius;

            //_8WaySymmetryPixel(x, y, xpos, ypos, color);

            while (ypos >= xpos)
            {
                //x,-y와 -x,-y가 r에 일치하면, -x,-y를참조시키고 리턴
                int distance = Math.Abs((int)Math.Sqrt(Math.Pow((xpos - (-xpos)), 2) + Math.Pow(-ypos - (-ypos), 2)));
                if (distance >= Math.Abs((int)(2 * radius / Math.Sqrt(2))))
                {
                    rectx = centerX - xpos;
                    recty = centerY - ypos;
                    return;
                }
                //  _8WaySymmetryPixel(x, y, ypos, xpos, color);
                if (d < 0)
                {
                    d += xpos * 2.0f + 1;
                    xpos++;
                }
                else
                {
                    d += (xpos - ypos) * 2.0f + 1;
                    xpos++;
                    ypos--;
                }
                
            }

            //MainPictureBox.Image = tempBitmap;
        }
        private void DrawCircleFill(int x, int y, int radius, int value)
        {
            DrawGrid();
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            Color color = Color.FromArgb(value, value, value);
            float d;

            int xpos = 0;
            int ypos = radius;

            d = 5.0f / 4 - radius;

            _8WaySymmetryPixelWithFill(x, y, xpos, ypos, color, Color.FromName("Red"));

            while (ypos >= xpos)
            {
                _8WaySymmetryPixelWithFill(x, y, xpos, ypos, color, Color.FromName("Red"));
                if (d < 0)
                {
                    d += xpos * 2.0f + 1;
                    xpos++;
                }
                else
                {
                    d += (xpos - ypos) * 2.0f + 1;
                    xpos++;
                    ypos--;
                }

            }

            MainPictureBox.Image = tempBitmap;
        }
        private void _8WaySymmetryPixelWithFill(int circleX, int circleY, int x, int y, Color color, Color fill)
        {
            Bitmap tempBitmap = MainPictureBox.Image as Bitmap;
            tempBitmap.SetPixel(circleX + x, circleY + y, color);
            tempBitmap.SetPixel(circleX - x, circleY + y, color);
            int tempy = circleY + y;
            for (int i = 0; i < x-1; i++)
            {
                tempBitmap.SetPixel(circleX - i, tempy, fill);
                tempBitmap.SetPixel(circleX + i, tempy, fill);
            }

            tempBitmap.SetPixel(circleX + y, circleY + x, color);
            tempBitmap.SetPixel(circleX - y, circleY + x, color);
            tempy = circleY + x;
            for (int i = 0; i < y - 1; i++)
            {
                tempBitmap.SetPixel(circleX - i, tempy, fill);
                tempBitmap.SetPixel(circleX + i, tempy, fill);
            }

            tempBitmap.SetPixel(circleX - y, circleY - x, color);
            tempBitmap.SetPixel(circleX + y, circleY - x, color);
            tempy = circleY - x;
            for (int i = 0; i < y - 1; i++)
            {
                tempBitmap.SetPixel(circleX - i, tempy, fill);
                tempBitmap.SetPixel(circleX + i, tempy, fill);
            }

            tempBitmap.SetPixel(circleX + x, circleY - y, color);
            tempBitmap.SetPixel(circleX - x, circleY - y, color);
            tempy = circleY -y;
            for (int i = 0; i < x - 1; i++)
            {
                tempBitmap.SetPixel(circleX - i, tempy, fill);
                tempBitmap.SetPixel(circleX + i, tempy, fill);
            }

            MainPictureBox.Image = tempBitmap;
        }
        private void DrawRect(int x, int y, int width, int height, int value, Color fill)
        {
            Bitmap image = MainPictureBox.Image as Bitmap;

            //outline
            for (int xpos = 0; xpos<width; xpos++)
            {
                image.SetPixel(x+xpos, y, Color.FromArgb(0,0,0));
                image.SetPixel(x+xpos, y+height, Color.FromArgb(0, 0, 0));
            }
            for(int ypos= 0; ypos < height; ypos++)
            {
                image.SetPixel(x, y+ypos, Color.FromArgb(0, 0, 0));
                image.SetPixel(x+width, y+ypos, Color.FromArgb(0, 0, 0));
            }

            //filling
            for(int ypos= y+1; ypos<y+height-1; ypos++)
            {
                for(int xpos = x+1; xpos<x+width-1; xpos++)
                {
                    image.SetPixel(xpos, ypos, fill);
                }
            }
            MainPictureBox.Image = image;
        }

        private void testToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DrawRect(0, 0, 200, 200, 0, Color.FromName("Blue"));
        }

        private void DrawTriangle(Point p1, Point p2, Point p3)
        {
            MidpointLine(p2.x, p2.y, p1.x, p1.y, 0);
            MidpointLine(p3.x, p3.y, p2.x, p2.y, 0);
            MidpointLine(p1.x, p1.y, p3.x, p3.y, 0);
        }
        private void triagleMoveNRoateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TriangleInput input = new TriangleInput();
            input.ShowDialog();
            int point1_x=0, point1_y=0, point2_x=0, point2_y=0, point3_x=0, point3_y=0;

            point1_x = input.point1_x;  point1_y = input.point1_y;
            point2_x = input.point2_x;  point2_y = input.point2_y;
            point3_x = input.point3_x;  point3_y = input.point3_y;

            Point[] Points = new Point[3];
            Points[0] = new Point(point1_x, point1_y);
            Points[1] = new Point(point2_x, point2_y);
            Points[2] = new Point(point3_x, point3_y);

            DrawGrid();
            DrawTriangle(Points[0], Points[1], Points[2]);

            int centerX = (point1_x + point2_x + point3_x) / 3;
            int centerY = (point1_y + point2_y + point3_y) / 3;
            Bitmap tempImage = MainPictureBox.Image as Bitmap;

            tempImage.SetPixel(centerX, centerY, Color.FromName("Red"));
            
            
            PointInput pinput = new PointInput();
            pinput.ShowDialog();

            Point trans = new Point(pinput.x, pinput.y);

            for (int i = 0; i < Points.Count(); i++)
                Points[i].AddTranslationVector(trans);

            MainPictureBox.Image = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            DrawGrid();
            DrawTriangle(Points[0], Points[1], Points[2]);

            string temp = "";
            if(InputBox("Input Angle", "angle : ", ref temp)==DialogResult.OK)
            {
                double theta = Double.Parse(temp);
    
                Point Center = Points[0].GetCenter(Points[1], Points[2]);
                /*
                for (int i = 0; i < Points.Count(); i++)
                    Points[i].AddTranslationVector(-Center.x, -Center.y);
                for (int i = 0; i < Points.Count(); i++)
                    Points[i].Rotation(theta);
                for (int i = 0; i < Points.Count(); i++)
                    Points[i].AddTranslationVector(+Center.x, +Center.y);
                */
                for (int i = 0; i < Points.Count(); i++)
                     Points[i].RotationFromCenter(theta, Center);
                MainPictureBox.Image = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
                DrawGrid();
                DrawTriangle(Points[0], Points[1], Points[2]);
            }
        }


        class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public Point GetCenter(Point p1, Point p2)
            {
                return GetCenter(p1, p2, this);
            }
            public Point GetCenter(Point p1, Point p2, Point p3)
            {
                int tempx = (p1.x + p2.x + p3.x) / 3;
                int tempy = (p1.y + p2.y + p3.y) / 2;
                return new Point(tempx, tempy);
            }
            public void AddTranslationVector(int tx, int ty)
            {
                x += tx;
                y += ty;
            }
            public void AddTranslationVector(Point p)
            {
                AddTranslationVector(p.x, p.y);
            }
            public void Rotation(double angle)
            {
                angle = angle*(Math.PI/180);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                x = (int)(cos * x - sin * y);
                y = (int)(sin * x + cos * y);

            }
            public void RotationFromCenter(double angle, Point center)
            {
                angle = angle * (Math.PI / 180);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                x = (int)(cos * x - sin * y);
                y = (int)(sin * x + cos * y);
            }
        }

        class Morpology
        {
            public int[][] set;

            public int originY;
            public int originX;

            public int size;
            public int widthLimit;
            public int heightLimit;

            Bitmap InputImage;
            Bitmap OutputImage;

            public Morpology(int size, Bitmap input, int ox, int oy)
            {
                this.InputImage = input.Clone() as Bitmap;
                this.size = size;
                widthLimit = InputImage.Width - size;
                heightLimit = InputImage.Height - size;

                set = new int[size][];
                for (int i = 0; i < size; i++)
                    set[i] = new int[size];

                originX = ox;
                originY = oy;

                OutputImage = input.Clone() as Bitmap;
            }
            public int Clipping(int x)
            {
                if (x > 255)
                    return 255;
                else if (x < 0)
                    return 0;
                else
                    return x;
            }
            public void setInitialize(int[][] newSet)
            {
                size = newSet.Count();

                for (int i = 0; i < set.Count(); i++)
                    for (int j = 0; j < set[i].Count(); j++)
                        set[i][j] = newSet[i][j];

                widthLimit = InputImage.Width - size;
                heightLimit = InputImage.Height - size;
            }
            public Bitmap Operation(string mod)
            {
                //Opening : Erosion->Dilation
                //Closing : Dilation->Erosion
                for (int y = 0; y < heightLimit; y++)
                {
                    for (int x = 0; x < widthLimit; x++)
                    {
                        int Origin;
                        Color originColor;
                        switch (mod)
                        {
                            case "Closing":
                            case "Dilation":
                                Origin = Dilation(x, y);
                                Origin = Clipping(Origin);
                                originColor = Color.FromArgb(Origin, Origin, Origin);
                                OutputImage.SetPixel(x + originX, y + originY, originColor);
                                break;
                            case "Opening":
                            case "Erosion":
                                Origin = Erosion(x, y);
                                Origin = Clipping(Origin);
                                originColor = Color.FromArgb(Origin, Origin, Origin);
                                OutputImage.SetPixel(x + originX, y + originY, originColor);
                                break;
                        }
                    }
                }

                if(mod.Equals("Opening") || mod.Equals("Closing"))
                {
                    InputImage = OutputImage.Clone() as Bitmap;
                    for (int y = 0; y < heightLimit; y++)
                    {
                        for (int x = 0; x < widthLimit; x++)
                        {
                            int Origin;
                            Color originColor;
                            switch (mod)
                            {
                                case "Closing":
                                    //do erosion
                                    Origin = Erosion(x, y);
                                    Origin = Clipping(Origin);
                                    originColor = Color.FromArgb(Origin, Origin, Origin);
                                    OutputImage.SetPixel(x+originX, y+originY, originColor);
                                    break;
                                case "Opening":
                                    //do dilation
                                    Origin = Dilation(x, y);
                                    Origin = Clipping(Origin);
                                    originColor = Color.FromArgb(Origin, Origin, Origin);
                                    OutputImage.SetPixel(x + originX, y + originY, originColor);
                                    break;
                            }
                        }
                    }
                }


                return OutputImage;
            }
            public int Dilation(int x, int y)//max
            {
                int max = 0;
                for (int ypos = 0; ypos < size; ypos++)
                {
                    for (int xpos = 0; xpos < size; xpos++)
                    {
                        if (set[xpos][ypos] == 1)
                        {
                            int value = (InputImage.GetPixel(x + xpos, y + ypos).R +
                                         InputImage.GetPixel(x + xpos, y + ypos).G +
                                         InputImage.GetPixel(x + xpos, y + ypos).B) / 3;
                            max = Math.Max(value, max);
                        }
                    }
                }
                return max;
            }

            public int Erosion(int x, int y)//min
            {
                int min = 255;
                for (int ypos = 0; ypos < size; ypos++)
                {
                    for (int xpos = 0; xpos < size; xpos++)
                    {
                        if (set[xpos][ypos] == 1)
                        {
                            int value = (InputImage.GetPixel(x + xpos, y + ypos).R +
                                         InputImage.GetPixel(x + xpos, y + ypos).G +
                                         InputImage.GetPixel(x + xpos, y + ypos).B) / 3;
                            min=Math.Min(value, min);
                        }
                    }
                }
                return min;
            }
        }
        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
            Morpology test = new Morpology(5, temp, 2,2);

            int[][] set = { new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 0, 0, 1, 0, 0 } };

            test.setInitialize(set);

            temp = test.Operation("Erosion");
            resultPictureBox.Image = temp;
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
            Morpology test = new Morpology(5, temp, 2, 2);

            int[][] set = { new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 0, 0 ,1, 0, 0 },
                            new int[]{ 0, 0, 1, 0, 0 } };


            test.setInitialize(set);

            temp = test.Operation("Dilation");
            resultPictureBox.Image = temp;
        }

        private void openningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
            Morpology test = new Morpology(5, temp, 2, 2);

            int[][] set = { new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1, 1, 1, 1 } };

            test.setInitialize(set);

            temp = test.Operation("Opening");
            resultPictureBox.Image = temp;
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temp = MainPictureBox.Image.Clone() as Bitmap;
            Morpology test = new Morpology(5, temp, 2, 2);

            int[][] set = { new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1 ,1, 1, 1 },
                            new int[]{ 1, 1, 1, 1, 1 } };

            test.setInitialize(set);

            temp = test.Operation("Closing");
            resultPictureBox.Image = temp;
        }

        private void bezierCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            Queue<Point> Points = new Queue<Point>();

            Graphics g = MainPictureBox.CreateGraphics();

            Scripts.IntegerInput iinput = new Scripts.IntegerInput();
            iinput.ShowDialog();

            if (!(iinput.value > 0))
                return;
            n = iinput.value;

            for (int i=0; i< n; i++)
            {
                PointInput pi = new PointInput();
                pi.ShowDialog();

                Point temp = new Point(pi.x, pi.y);
                Points.Enqueue(temp);
            }

            Point[] tPoints = Points.ToArray<Point>();
            Pen pen = new Pen(Color.Black, 0.5f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            for(int i=1; i< n;i++)
            {
                PointF arg1 = new PointF(tPoints[i - 1].x, tPoints[i - 1].y);
                PointF arg2 = new PointF(tPoints[i].x, tPoints[i].y);

                g.DrawLine(pen, arg1, arg2);
            }

            Point[] arr = DrawCurve(Points.ToArray<Point>(), Points.Count());
            PointF[] curvePoints = new PointF[n+1];
            for(int i=0;i<curvePoints.Count(); i++)
            {
                curvePoints[i] = new PointF(arr[i].x, arr[i].y);
            }
            
            g.DrawCurve(new Pen(Color.Black, 2.0f) ,curvePoints);
        }

        private Point[] DrawCurve(Point[] ControlPoints, int n)
        {
            int i;
            float t, delta;
            Point[] CurvePoints = new Point[n+1];

            int tx = ControlPoints[0].x;
            int ty = ControlPoints[0].y;
            CurvePoints[0] = new Point(tx, ty);

            delta = (float)1.0 / n;

            for(i=1; i<=n; i++)
            {
                t = i * delta;

                int cpx = (int)(ControlPoints[0].x * (1.0 - t) * (1.0 - t) * (1.0 - t) +
                        ControlPoints[1].x * 3.0 * t * (1.0 - t) * (1.0 - t) +
                        ControlPoints[2].x * 3.0 * t * t * (1.0 - t) +
                        ControlPoints[3].x * t * t * t);
                int cpy = (int)(ControlPoints[0].y * (1.0 - t) * (1.0 - t) * (1.0 - t) +
                        ControlPoints[1].y * 3.0 * t * (1.0 - t) * (1.0 - t) +
                        ControlPoints[2].y * 3.0 * t * t * (1.0 - t) +
                        ControlPoints[3].y * t * t * t);
                CurvePoints[i] = new Point(cpx, cpy);
            }
            return CurvePoints;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void downSamplingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap temp;
            Bitmap output = new Bitmap(input.Width / 2, input.Height/2);

            for(int i=1;i<output.Height&& 2*i<input.Height; i++)
            {
                for(int j=1;j<output.Width && 2*j<input.Width;j++)
                {
                    output.SetPixel(j, i,input.GetPixel(2*j, 2*i));
                }
            }
            temp = new Bitmap(input.Width, input.Height);
            for(int i=0;i<output.Height; i++)
            {
                for(int j=0;j<output.Width; j++)
                {
                    temp.SetPixel(j, i, output.GetPixel(j, i));
                }
            }
            resultPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            MainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            resultPictureBox.Image = output;
            
        }

        private void interpolationCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width * 2, input.Height * 2);

            for(int i=0; i<output.Height; i+=2)
            {
                for(int j=0; j<output.Width; j+=2)
                {
                    Color fill = input.GetPixel(j/2, i/2);
                    output.SetPixel(j,i,fill);
                    output.SetPixel(j+1, i, fill);
                    output.SetPixel(j+1, i+1, fill);
                    output.SetPixel(j, i+1, fill);
                }
            }
            resultPictureBox.Image = output;
            resultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void interpolationAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width * 2, input.Height * 2);

            for (int i = 0; i < output.Height && i+2<output.Height; i += 2)
            {
                for (int j = 0; j < output.Width && j+2<output.Width; j += 2)
                {
                    if (i >= output.Height || j >= output.Width)
                        break;

                    Color colorOrigin = input.GetPixel(j / 2, i / 2);
                    Color colorRight = input.GetPixel((j / 2)+1, (i / 2));
                    Color colorDown = input.GetPixel((j/2), (i/2)+1);
                    Color colorDownRight = input.GetPixel((j/2)+1, (i/2)+1);

                    int tempR = (colorRight.R + colorOrigin.R) / 2;
                    int tempG = (colorRight.G + colorOrigin.G) / 2;
                    int tempB = (colorRight.B + colorOrigin.B) / 2;
                    colorRight = Color.FromArgb(tempR, tempG, tempB);

                    tempR = (colorOrigin.R + colorDown.R) / 2;
                    tempG = (colorOrigin.G + colorDown.G) / 2;
                    tempB = (colorOrigin.B + colorDown.B) / 2;
                    colorDown = Color.FromArgb(tempR, tempG, tempB);

                    tempR = (colorOrigin.R + colorDownRight.R) / 2;
                    tempG = (colorOrigin.G + colorDownRight.G) / 2;
                    tempB = (colorOrigin.B + colorDownRight.B) / 2;
                    colorDownRight = Color.FromArgb(tempR, tempG, tempB);

                    PointF TargetRight = new PointF(j + 1, i);
                    PointF TargetDown = new PointF(j, i + 1);
                    PointF TargetDownRight = new PointF(j + 1, i + 1);

                    output.SetPixel(j, i, colorOrigin);
                    output.SetPixel((int)TargetRight.X, (int)TargetRight.Y, colorRight);
                    output.SetPixel((int)TargetDown.X, (int)TargetDown.Y, colorDown);
                    output.SetPixel((int)TargetDownRight.X, (int)TargetDownRight.Y, colorDownRight);
                }
            }
            resultPictureBox.Image = output;
            resultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void lowBit0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);

            for(int y=0;y<input.Height; y++)
            {
                for(int x=0; x<input.Width; x++)
                {
                    uint tempR = input.GetPixel(x, y).R;
                    uint tempG = input.GetPixel(x, y).G;
                    uint tempB = input.GetPixel(x, y).B;

                    tempR = tempR << 4;
                    tempG = tempG << 4;
                    tempB = tempB << 4;
                    output.SetPixel(x, y, Color.FromArgb((int)tempR, (int)tempG, (int)tempB));
                }
            }

            resultPictureBox.Image = output;           
        }

        private void truncationCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    uint tempR = input.GetPixel(x, y).R;
                    uint tempG = input.GetPixel(x, y).G;
                    uint tempB = input.GetPixel(x, y).B;

                    tempR = tempR >> 4;
                    tempG = tempG >> 4;
                    tempB = tempB >> 4;
                    output.SetPixel(x, y, Color.FromArgb((int)tempR, (int)tempG, (int)tempB));
                }
            }
            resultPictureBox.Image = output;
        }

        private void lowBit8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    uint tempR = input.GetPixel(x, y).R;
                    uint tempG = input.GetPixel(x, y).G;
                    uint tempB = input.GetPixel(x, y).B;

                    tempR = (tempR << 4) +8;
                    tempG = (tempG << 4) +8;
                    tempB = (tempB << 4) +8;

                    if (tempR > 255) tempR = 255;
                    if (tempG > 255) tempG = 255;
                    if (tempB > 255) tempB = 255;


                    output.SetPixel(x, y, Color.FromArgb((int)tempR, (int)tempG, (int)tempB));
                }
            }

            resultPictureBox.Image = output;
        }

        private void randomLowBitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);
            Random rand = new Random();
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    uint tempR = input.GetPixel(x, y).R;
                    uint tempG = input.GetPixel(x, y).G;
                    uint tempB = input.GetPixel(x, y).B;
                    
                    tempR = (tempR << 4) + (uint)rand.Next(0,16);
                    tempG = (tempG << 4) + (uint)rand.Next(0, 16);
                    tempB = (tempB << 4) + (uint)rand.Next(0, 16);
                    output.SetPixel(x, y, Color.FromArgb((int)tempR, (int)tempG, (int)tempB));
                }
            }

            resultPictureBox.Image = output;
        }

        private void compressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);

            DctObject = new DCT(input, output, 1);

            DctObject.DoDCT(input, output);


            resultPictureBox.Image = DctObject.GetOutputFromRGBBuffer();
        }
       

        private void decompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap input = MainPictureBox.Image as Bitmap;
            Bitmap output = new Bitmap(input.Width, input.Height);

            DctObject.DoReverseDCT();
            
            resultPictureBox.Image = DctObject.GetOutputFromRGBBuffer();
        }

        class DCT
        {
            Bitmap input;
            Bitmap output;

            Bitmap temp;

            int blockSize = 8;

            int[][] RBuffer;
            int[][] GBuffer;
            int[][] BBuffer;

            int quantizationLevel;
            int[][] QuantizationValues;

            double[][] DCTValues =  new double[][]
                                    {
                                        new double[8] { 0.353553,   0.353553,   0.353553,   0.353553,   0.353553,   0.353553,   0.353553,   0.353553    },
                                        new double[8] { 0.490393,   0.415735,   0.277785,   0.097545,  -0.09755,   -0.27779,   -0.41574,   -0.49039     },
                                        new double[8] { 0.46194,    0.191342,  -0.19134,   -0.46194,   -0.46194,   -0.19134,    0.191342,   0.46194     },
                                        new double[8] { 0.415735,  -0.09755,   -0.49039,   -0.27779,    0.277785,   0.490393,   0.097545,  -0.41574     },
                                        new double[8] { 0.353553,  -0.35355,   -0.35355,    0.353553,   0.353553,  -0.35355,   -0.35355,    0.353553    },
                                        new double[8] { 0.277785,  -0.49039,    0.097545,   0.415735,   -0.41574,   -0.09755,    0.490393,  -0.27779    },
                                        new double[8] { 0.191342,  -0.46194,    0.46194,   -0.19134,   -0.19134,    0.46194,   -0.46194,    0.191342    },
                                        new double[8] { 0.097545,  -0.27779,    0.415735,  -0.49039,    0.490393,  -0.41574,    0.277785,  -0.09755     },
                                    };
            double[][] ReverseDCTValues;
            public void SetRGBBuffer()
            {
                for(int i=0; i<input.Height; i++)
                {
                    for(int j=0; j<input.Width; j++)
                    {
                        RBuffer[i][j] = input.GetPixel(j, i).R;
                        GBuffer[i][j] = input.GetPixel(j, i).G;
                        BBuffer[i][j] = input.GetPixel(j, i).B;
                    }
                }
            }
            public DCT(Bitmap input, Bitmap output, int ql)
            {
                this.input = input.Clone() as Bitmap;
                this.output = new Bitmap(input.Width, input.Height);
                this.temp = new Bitmap(input.Width, input.Height);

                this.quantizationLevel = ql;

                this.RBuffer = new int[input.Height][];
                this.GBuffer = new int[input.Height][];
                this.BBuffer = new int[input.Height][];

                for(int i=0;i<RBuffer.Count(); i++)
                {
                    RBuffer[i] = new int[input.Width];
                    GBuffer[i] = new int[input.Width];
                    BBuffer[i] = new int[input.Width];
                }

                this.QuantizationValues = new int[8][];
                this.ReverseDCTValues = new double[8][];

                for(int i=0;i<blockSize; i++)
                {
                    this.RBuffer[i] = new int[input.Width];
                    this.GBuffer[i] = new int[input.Width];
                    this.BBuffer[i] = new int[input.Width];

                    this.QuantizationValues[i] = new int[8];
                    this.ReverseDCTValues[i] = new double[8];

                }

                for (int i = 0; i < DCTValues.Count(); i++)
                    for (int j = 0; j < DCTValues[i].Count(); j++)
                        this.ReverseDCTValues[j][i] = this.DCTValues[i][j];

                this.QuantizationValues = new int[][]
                                        {
                                            new int[] { 16, 11, 10, 16, 24, 40, 51, 61  },
                                            new int[] { 12, 12, 14, 19, 26, 58, 60, 55  },
                                            new int[] { 14, 13, 16, 24, 40, 57, 69, 56  },
                                            new int[] { 14, 17, 22, 29, 51, 87, 80, 62  },
                                            new int[] { 18, 22, 37, 56, 68, 109,103,77  },
                                            new int[] { 24, 35, 55, 64, 81, 104,113,92  },
                                            new int[] { 49, 64, 78, 87, 103,121,120,101 },
                                            new int[] { 72, 92, 95, 98, 112,100,103,99  }
                                            /*
                                            new int[] { 17,18,24,47,99,99,99,99 },
                                            new int[] { 18, 21, 26, 66, 99, 99, 99, 99 },
                                            new int[] { 24, 26, 56, 99, 99, 99, 99, 99 },
                                            new int[] { 47, 66, 99, 99, 99, 99, 99, 99 },
                                            new int[] { 99, 99, 99, 99, 99, 99, 99, 99 },
                                            new int[] { 99, 99, 99, 99, 99, 99, 99, 99 },
                                            new int[] { 99, 99, 99, 99, 99, 99, 99, 99 },
                                            new int[] { 99, 99, 99, 99, 99, 99, 99, 99 }*/
                                        };                
            }

            public void DoDCT()
            {   DoDCT(this.input, this.output); }

            public void DoDCT(Bitmap i, Bitmap o)
            {
                SetRGBBuffer();
                //y-side
                for(int y=0;y<=input.Height-8; y+=8)
                {
                    for(int x=0; x<=input.Width-8; x+=8)
                    {
                        YsideMaskDCT(i, o, x,y);
                    }
                }

                //x-side
                for (int y = 0; y <= input.Height - 8; y += 8)
                {
                    for (int x = 0; x <= input.Width - 8; x += 8)
                    {
                        XsideReverseDCT(i, o, x, y);
//                        XsideMaskDCT(i, o, x, y);
                    }
                }
            }
            public void Quantization()
            {
                for (int a = 0; a < RBuffer.Length; a++)
                {
                    for (int b = 0; b < RBuffer[a].Length; b++)
                    {
                        RBuffer[a][b] = (RBuffer[a][b] / QuantizationValues[a % 8][b % 8]) / quantizationLevel;
                        GBuffer[a][b] = (GBuffer[a][b] / QuantizationValues[a % 8][b % 8]) / quantizationLevel;
                        BBuffer[a][b] = (BBuffer[a][b] / QuantizationValues[a % 8][b % 8]) / quantizationLevel;
/*
                        RBuffer[a][b] = (RBuffer[a][b] / QuantizationValues[b % 8][a % 8]) / quantizationLevel;
                        GBuffer[a][b] = (GBuffer[a][b] / QuantizationValues[b % 8][a % 8]) / quantizationLevel;
                        BBuffer[a][b] = (BBuffer[a][b] / QuantizationValues[b % 8][a % 8]) / quantizationLevel;
*/
                    }
                }
            }
            public void ReverseQuantization()
            {
                for(int i=0;i<RBuffer.Count(); i++)
                {
                    for(int j=0; j<RBuffer[i].Count(); j++)
                    {
                        /*
                                                RBuffer[i][j] = RBuffer[i][j] * (QuantizationValues[j % 8][i % 8] * quantizationLevel);
                                                GBuffer[i][j] = GBuffer[i][j] * (QuantizationValues[j % 8][i % 8] * quantizationLevel);
                                                BBuffer[i][j] = BBuffer[i][j] * (QuantizationValues[j % 8][i % 8] * quantizationLevel);
                        */
                        RBuffer[i][j] = RBuffer[i][j] * (QuantizationValues[i % 8][j % 8] * quantizationLevel);
                        GBuffer[i][j] = GBuffer[i][j] * (QuantizationValues[i % 8][j % 8] * quantizationLevel);
                        BBuffer[i][j] = BBuffer[i][j] * (QuantizationValues[i % 8][j % 8] * quantizationLevel);
                    }
                }
            }
            public void SetQuantizationLevel(int ql)
            {   this.quantizationLevel = ql;    }
            public void DoReverseDCT()
            {   DoReverseDCT(this.input, this.output);  }
            public void DoReverseDCT(Bitmap input, Bitmap output)
            {
                //x에 대해 y성분 DCT
                for(int x=0;x<=input.Width-8;x+=8)
                {
                    for(int y=0; y<=input.Height-8; y+=8)
                    {
                        XsideReverseDCT(input, output, x, y);
                        //XsideMaskDCT(input, output, x, y);
                       // YsideReverseDCT(input, output, x, y);
                    }
                }
                //y에 대해 x성분 DCT
                for (int x = 0; x <= input.Width - 8; x += 8)
                {
                    for (int y = 0; y <= input.Height - 8; y += 8)
                    {
                        //YsideMaskDCT(input, output, x, y);
                        YsideReverseDCT(input, output, x, y);
                        //XsideReverseDCT(input, output, x, y);
                    }
                }
            }
            public void YsideReverseDCT(Bitmap input, Bitmap output, int xOrigin, int yOrigin)
            {
                int[][] tempR = new int[blockSize][];
                int[][] tempG = new int[blockSize][];
                int[][] tempB = new int[blockSize][];
                for (int i = 0; i < blockSize; i++)
                {
                    tempR[i] = new int[blockSize];
                    tempG[i] = new int[blockSize];
                    tempB[i] = new int[blockSize];
                }


                for (int y = 0; y < blockSize; y++)
                {
                    for (int x = 0; x < blockSize; x++)
                    {
                        tempR[y][x] = RBuffer[y + yOrigin][x + xOrigin];
                        tempG[y][x] = GBuffer[y + yOrigin][x + xOrigin];
                        tempB[y][x] = BBuffer[y + yOrigin][x + xOrigin];
                    }
                }

                tempR = DCTMatrixMultiplication(tempR, ReverseDCTValues);
                tempG = DCTMatrixMultiplication(tempG, ReverseDCTValues);
                tempB = DCTMatrixMultiplication(tempB, ReverseDCTValues);

                for (int x = 0; x < blockSize; x++)
                {
                    //해당 위치에 값할당(rgBBuffer)
                    for (int cnt = 0; cnt < blockSize; cnt++)
                    {
                        RBuffer[yOrigin + cnt][x + xOrigin] = tempR[cnt][x];
                        GBuffer[yOrigin + cnt][x + xOrigin] = tempG[cnt][x];
                        BBuffer[yOrigin + cnt][x + xOrigin] = tempB[cnt][x];
                    }
                }
            }
            public void XsideReverseDCT(Bitmap input, Bitmap output, int xOrigin, int yOrigin)
            {
                int[][] tempR = new int[blockSize][];
                int[][] tempG = new int[blockSize][];
                int[][] tempB = new int[blockSize][];
                for(int i=0; i<blockSize;i++)
                {
                    tempR[i] = new int[blockSize];
                    tempG[i] = new int[blockSize];
                    tempB[i] = new int[blockSize]; 
                }


                for(int x=0; x<blockSize;x++)
                {
                    for (int y = 0; y < blockSize; y++)
                    {
                        tempR[x][y] = RBuffer[y + yOrigin][x + xOrigin];
                        tempG[x][y] = GBuffer[y + yOrigin][x + xOrigin];
                        tempB[x][y] = BBuffer[y + yOrigin][x + xOrigin];
                    }
                }
                tempR = DCTMatrixMultiplication(ReverseDCTValues,tempR);
                tempG = DCTMatrixMultiplication(ReverseDCTValues,tempG);
                tempB = DCTMatrixMultiplication(ReverseDCTValues,tempB);

                for (int y = 0; y < blockSize; y++)
                {
                    //해당 위치에 값할당(rgBBuffer)
                    for (int cnt = 0; cnt < blockSize; cnt++)
                    {
                        RBuffer[yOrigin + y][cnt + xOrigin] = tempR[y][cnt];
                        GBuffer[yOrigin + y][cnt + xOrigin] = tempG[y][cnt];
                        BBuffer[yOrigin + y][cnt + xOrigin] = tempB[y][cnt];

                    }
                    //RGB값 얻음(from BufferTable)
                    //y에 대한 x성분들 할당
                    //행렬 곱 연산
                    //해당 위치에 값 할당(RGBbuffer)
                }
            }

            public void YsideMaskDCT(Bitmap i, Bitmap o, int xOrigin, int yOrigin)
            {
                int[][] tempR = new int[blockSize][];
                int[][] tempG = new int[blockSize][];
                int[][] tempB = new int[blockSize][];
                for (int a = 0; a < blockSize; a++)
                {
                    tempR[a] = new int[blockSize];
                    tempG[a] = new int[blockSize];
                    tempB[a] = new int[blockSize];
                }


                for (int y = 0; y < blockSize; y++)
                {
                    for (int x = 0; x < blockSize; x++)
                    {
                        tempR[y][x] = RBuffer[y + yOrigin][x + xOrigin];
                        tempG[y][x] = GBuffer[y + yOrigin][x + xOrigin];
                        tempB[y][x] = BBuffer[y + yOrigin][x + xOrigin];
                    }
                }


                //행렬 곱 연산
                tempR = DCTMatrixMultiplication(tempR);
                tempG = DCTMatrixMultiplication(tempG);
                tempB = DCTMatrixMultiplication(tempB);
                for (int x = 0; x < blockSize; x++)
                {
                    //해당 위치에 값할당(rgBBuffer)
                    for (int cnt=0; cnt<blockSize; cnt++)
                    {
                        RBuffer[yOrigin + cnt][x + xOrigin] = tempR[cnt][x];
                        GBuffer[yOrigin + cnt][x + xOrigin] = tempG[cnt][x];
                        BBuffer[yOrigin + cnt][x + xOrigin] = tempB[cnt][x];
                    }
                }
            }

            //수정중
            public void XsideMaskDCT(Bitmap i, Bitmap o, int xOrigin, int yOrigin)
            {
                int[][] tempR = new int[blockSize][];
                int[][] tempG = new int[blockSize][];
                int[][] tempB = new int[blockSize][];

                int[][] Rresult = new int[blockSize][];
                int[][] Gresult = new int[blockSize][];
                int[][] Bresult = new int[blockSize][];

                for (int j = 0; j < blockSize; j++)
                {
                    tempR[j] = new int[blockSize];
                    tempG[j] = new int[blockSize];
                    tempB[j] = new int[blockSize];
                }

                //해당 위치 값 추출
                for (int y = 0; y < blockSize; y++)
                {
                    for (int x = 0; x < blockSize; x++)
                    {
                        tempR[y][x] = RBuffer[y][x];
                        tempG[y][x] = RBuffer[y][x];
                        tempB[y][x] = RBuffer[y][x];
                    }
                }
                               
                //행렬 곱 연산
                Rresult = DCTMatrixMultiplication(tempR);
                Gresult = DCTMatrixMultiplication(tempG);
                Bresult = DCTMatrixMultiplication(tempB);
                for (int y = 0; y < blockSize; y++)
                {
                    //해당 위치에 값할당(rgBBuffer)
                    for (int cnt = 0; cnt < blockSize; cnt++)
                    {
                        RBuffer[yOrigin + y][cnt + xOrigin] = Rresult[y][cnt];
                        GBuffer[yOrigin + y][cnt + xOrigin] = Gresult[y][cnt];
                        BBuffer[yOrigin + y][cnt + xOrigin] = Bresult[y][cnt];
                    }
                }
            }
            public int[][] DCTMatrixMultiplication(int[][] a)
            {
                if (DCTValues[0].Count() != a.Count())
                    return null;
                
                double[][] result = new double[DCTValues.Count()][];

                for (int cnt = 0; cnt < result.Count(); cnt++)
                    result[cnt] = new double[a[0].Count()];

                for (int i = 0; i < result.Count(); i++)
                {
                    result[i] = new double[a[i].Count()];
                    for (int j = 0; j < result[i].Count(); j++)
                        result[i][j] = 0;
                }

                for(int row=0;row<DCTValues.Count(); row++)
                    for(int col=0; col<a[row].Count(); col++)
                        for(int inner = 0; inner<DCTValues[row].Count(); inner++)
                            result[row][col] += (DCTValues[row][inner] * a[inner][col]);

                int[][] returnArray = new int[result.Count()][];
                for (int i = 0; i < returnArray.Count(); i++)
                    returnArray[i] = new int[result[i].Count()];

                for (int i = 0; i < returnArray.Count(); i++)
                    for (int j = 0; j < returnArray[i].Count(); j++)
                        returnArray[i][j] = (int)result[i][j];

                return returnArray;
            }
            public int[][] DCTMatrixMultiplication(int[][] b,double[][] a)
            {
                if (b[0].Count() != a.Count())
                    return null;

                double[][] result = new double[b.Count()][];

                for (int cnt = 0; cnt < result.Count(); cnt++)
                    result[cnt] = new double[a[0].Count()];

                for (int i = 0; i < result.Count(); i++)
                {
                    result[i] = new double[a[i].Count()];
                    for (int j = 0; j < result[i].Count(); j++)
                        result[i][j] = 0;
                }

                for (int row = 0; row < b.Count(); row++)
                    for (int col = 0; col < a[row].Count(); col++)
                        for (int inner = 0; inner < b[row].Count(); inner++)
                            result[row][col] += (b[row][inner] * a[inner][col]);

                int[][] returnArray = new int[result.Count()][];
                for (int i = 0; i < returnArray.Count(); i++)
                    returnArray[i] = new int[result[i].Count()];

                for (int i = 0; i < returnArray.Count(); i++)
                    for (int j = 0; j < returnArray[i].Count(); j++)
                        returnArray[i][j] = (int)result[i][j];

                return returnArray;
            }

            public int[][] DCTMatrixMultiplication(double[][] b, int[][] a)
            {
                if (b[0].Count() != a.Count())
                    return null;

                double[][] result = new double[b.Count()][];

                for (int cnt = 0; cnt < result.Count(); cnt++)
                    result[cnt] = new double[a[0].Count()];

                for (int i = 0; i < result.Count(); i++)
                {
                    result[i] = new double[a[i].Count()];
                    for (int j = 0; j < result[i].Count(); j++)
                        result[i][j] = 0;
                }

                for (int row = 0; row < b.Count(); row++)
                    for (int col = 0; col < a[row].Count(); col++)
                        for (int inner = 0; inner < b[row].Count(); inner++)
                            result[row][col] += (b[row][inner] * a[inner][col]);

                int[][] returnArray = new int[result.Count()][];
                for (int i = 0; i < returnArray.Count(); i++)
                    returnArray[i] = new int[result[i].Count()];

                for (int i = 0; i < returnArray.Count(); i++)
                    for (int j = 0; j < returnArray[i].Count(); j++)
                        returnArray[i][j] = (int)result[i][j];

                return returnArray;
            }


            public Bitmap GetOutputFromRGBBuffer()
            {
                for(int y=0;y<RBuffer.Count();y++)
                {
                    for(int x=0; x<RBuffer[y].Count(); x++)
                    {
                        int r = RBuffer[y][x];
                        int g = GBuffer[y][x];
                        int b = BBuffer[y][x];

                        if (r > 255) r = 255;
                        if (g > 255) g = 255;
                        if (b > 255) b = 255;

                        if (r < 0) r = 0;
                        if (g < 0) g = 0;
                        if (b < 0) b = 0;
                        
                        output.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                return output.Clone() as Bitmap;
            }
        }

        private void qunatizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DctObject.Quantization();
            resultPictureBox.Image = DctObject.GetOutputFromRGBBuffer();
        }

        private void reverseQuantizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DctObject.ReverseQuantization();
            resultPictureBox.Image = DctObject.GetOutputFromRGBBuffer();
        }

        private void setQuantizationLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts.IntegerInput iinput = new Scripts.IntegerInput();
            iinput.ShowDialog();

            int value = iinput.value;
            if (value > 10)
                value = 10;
            if (value < 1)
                value = 1;

            DctObject.SetQuantizationLevel(value);
        }

        private void resetDCTObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DctObject = null;
        }
    }
}


