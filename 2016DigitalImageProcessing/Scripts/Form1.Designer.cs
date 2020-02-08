using System;

namespace _2016DigitalImageProcessing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeCompnent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenedFileList = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiSaveSaveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDALineDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamMidpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamMidpointCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.report02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureRotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleNRectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triagleMoveNRoateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bezierCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digitalImageProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowpassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highpassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatingSaltAndPepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.고주파강조ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arithmeticalOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mathmaticalMorphologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downSamplingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downSamplingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolationCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolationAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lowBit0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowBit8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomLowBitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncationCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qunatizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseQuantizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setQuantizationLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.resultAdjustButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.resetDCTObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Location = new System.Drawing.Point(8, 58);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(500, 500);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPictureBox.TabIndex = 1;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "File Open";
            // 
            // OpenedFileList
            // 
            this.OpenedFileList.FormattingEnabled = true;
            this.OpenedFileList.Location = new System.Drawing.Point(8, 36);
            this.OpenedFileList.Name = "OpenedFileList";
            this.OpenedFileList.Size = new System.Drawing.Size(1083, 20);
            this.OpenedFileList.TabIndex = 3;
            this.OpenedFileList.SelectedIndexChanged += new System.EventHandler(this.OpenedFileListSelect);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(512, 535);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "ClearAll";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearAllButtonClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.computerGraphicsToolStripMenuItem,
            this.digitalImageProcessingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.multiSaveSaveAllToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // multiSaveSaveAllToolStripMenuItem
            // 
            this.multiSaveSaveAllToolStripMenuItem.Name = "multiSaveSaveAllToolStripMenuItem";
            this.multiSaveSaveAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.multiSaveSaveAllToolStripMenuItem.Text = "Multi Save(Save all)";
            this.multiSaveSaveAllToolStripMenuItem.Click += new System.EventHandler(this.multiSaveSaveAllToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // computerGraphicsToolStripMenuItem
            // 
            this.computerGraphicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineDrawingToolStripMenuItem,
            this.circleDrawingToolStripMenuItem,
            this.report02ToolStripMenuItem,
            this.bezierCurveToolStripMenuItem});
            this.computerGraphicsToolStripMenuItem.Name = "computerGraphicsToolStripMenuItem";
            this.computerGraphicsToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.computerGraphicsToolStripMenuItem.Text = "ComputerGraphics";
            // 
            // lineDrawingToolStripMenuItem
            // 
            this.lineDrawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDALineDrawingToolStripMenuItem,
            this.bresenhamMidpointToolStripMenuItem,
            this.testToolStripMenuItem});
            this.lineDrawingToolStripMenuItem.Name = "lineDrawingToolStripMenuItem";
            this.lineDrawingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lineDrawingToolStripMenuItem.Text = "LineDrawing";
            // 
            // dDALineDrawingToolStripMenuItem
            // 
            this.dDALineDrawingToolStripMenuItem.Name = "dDALineDrawingToolStripMenuItem";
            this.dDALineDrawingToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dDALineDrawingToolStripMenuItem.Text = "DDA LineDrawing";
            this.dDALineDrawingToolStripMenuItem.Click += new System.EventHandler(this.dDALineDrawingToolStripMenuItem_Click);
            // 
            // bresenhamMidpointToolStripMenuItem
            // 
            this.bresenhamMidpointToolStripMenuItem.Name = "bresenhamMidpointToolStripMenuItem";
            this.bresenhamMidpointToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.bresenhamMidpointToolStripMenuItem.Text = "Bresenham Midpoint";
            this.bresenhamMidpointToolStripMenuItem.Click += new System.EventHandler(this.bresenhamMidpointToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // circleDrawingToolStripMenuItem
            // 
            this.circleDrawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bresenhamMidpointCircleToolStripMenuItem});
            this.circleDrawingToolStripMenuItem.Name = "circleDrawingToolStripMenuItem";
            this.circleDrawingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.circleDrawingToolStripMenuItem.Text = "CircleDrawing";
            // 
            // bresenhamMidpointCircleToolStripMenuItem
            // 
            this.bresenhamMidpointCircleToolStripMenuItem.Name = "bresenhamMidpointCircleToolStripMenuItem";
            this.bresenhamMidpointCircleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.bresenhamMidpointCircleToolStripMenuItem.Text = "Bresenham Midpoint Circle";
            this.bresenhamMidpointCircleToolStripMenuItem.Click += new System.EventHandler(this.bresenhamMidpointCircleToolStripMenuItem_Click);
            // 
            // report02ToolStripMenuItem
            // 
            this.report02ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureRotateToolStripMenuItem,
            this.circleNRectToolStripMenuItem,
            this.triagleMoveNRoateToolStripMenuItem,
            this.testToolStripMenuItem2});
            this.report02ToolStripMenuItem.Name = "report02ToolStripMenuItem";
            this.report02ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.report02ToolStripMenuItem.Text = "Report#02";
            // 
            // pictureRotateToolStripMenuItem
            // 
            this.pictureRotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectionToolStripMenuItem});
            this.pictureRotateToolStripMenuItem.Name = "pictureRotateToolStripMenuItem";
            this.pictureRotateToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.pictureRotateToolStripMenuItem.Text = "#01_PictureRotate";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upDownToolStripMenuItem,
            this.leftRightToolStripMenuItem});
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.reflectionToolStripMenuItem.Text = "Reflection";
            // 
            // upDownToolStripMenuItem
            // 
            this.upDownToolStripMenuItem.Name = "upDownToolStripMenuItem";
            this.upDownToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.upDownToolStripMenuItem.Text = "Up&Down";
            this.upDownToolStripMenuItem.Click += new System.EventHandler(this.upDownToolStripMenuItem_Click);
            // 
            // leftRightToolStripMenuItem
            // 
            this.leftRightToolStripMenuItem.Name = "leftRightToolStripMenuItem";
            this.leftRightToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.leftRightToolStripMenuItem.Text = "LeftRight";
            this.leftRightToolStripMenuItem.Click += new System.EventHandler(this.leftRightToolStripMenuItem_Click);
            // 
            // circleNRectToolStripMenuItem
            // 
            this.circleNRectToolStripMenuItem.Name = "circleNRectToolStripMenuItem";
            this.circleNRectToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.circleNRectToolStripMenuItem.Text = "#02_CircleNRect";
            this.circleNRectToolStripMenuItem.Click += new System.EventHandler(this.circleNRectToolStripMenuItem_Click);
            // 
            // triagleMoveNRoateToolStripMenuItem
            // 
            this.triagleMoveNRoateToolStripMenuItem.Name = "triagleMoveNRoateToolStripMenuItem";
            this.triagleMoveNRoateToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.triagleMoveNRoateToolStripMenuItem.Text = "#03_Triagle_MoveNRoate";
            this.triagleMoveNRoateToolStripMenuItem.Click += new System.EventHandler(this.triagleMoveNRoateToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem2
            // 
            this.testToolStripMenuItem2.Name = "testToolStripMenuItem2";
            this.testToolStripMenuItem2.Size = new System.Drawing.Size(209, 22);
            this.testToolStripMenuItem2.Text = "Test";
            this.testToolStripMenuItem2.Click += new System.EventHandler(this.testToolStripMenuItem2_Click);
            // 
            // bezierCurveToolStripMenuItem
            // 
            this.bezierCurveToolStripMenuItem.Name = "bezierCurveToolStripMenuItem";
            this.bezierCurveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bezierCurveToolStripMenuItem.Text = "Bezier Curve";
            this.bezierCurveToolStripMenuItem.Click += new System.EventHandler(this.bezierCurveToolStripMenuItem_Click);
            // 
            // digitalImageProcessingToolStripMenuItem
            // 
            this.digitalImageProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.arithmeticalOperationToolStripMenuItem,
            this.mathmaticalMorphologyToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.quantizationToolStripMenuItem});
            this.digitalImageProcessingToolStripMenuItem.Name = "digitalImageProcessingToolStripMenuItem";
            this.digitalImageProcessingToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.digitalImageProcessingToolStripMenuItem.Text = "DigitalImageProcessing";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowpassFilterToolStripMenuItem,
            this.highpassFilterToolStripMenuItem,
            this.medianFilterToolStripMenuItem,
            this.testToolStripMenuItem1,
            this.grayscaleToolStripMenuItem,
            this.generatingSaltAndPepperToolStripMenuItem,
            this.negativeFilterToolStripMenuItem,
            this.고주파강조ToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // lowpassFilterToolStripMenuItem
            // 
            this.lowpassFilterToolStripMenuItem.Name = "lowpassFilterToolStripMenuItem";
            this.lowpassFilterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.lowpassFilterToolStripMenuItem.Text = "Lowpass Filter";
            this.lowpassFilterToolStripMenuItem.Click += new System.EventHandler(this.lowpassFilterToolStripMenuItem_Click);
            // 
            // highpassFilterToolStripMenuItem
            // 
            this.highpassFilterToolStripMenuItem.Name = "highpassFilterToolStripMenuItem";
            this.highpassFilterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.highpassFilterToolStripMenuItem.Text = "Highpass Filter";
            this.highpassFilterToolStripMenuItem.Click += new System.EventHandler(this.highpassFilterToolStripMenuItem_Click);
            // 
            // medianFilterToolStripMenuItem
            // 
            this.medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            this.medianFilterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.medianFilterToolStripMenuItem.Text = "Median Filter";
            this.medianFilterToolStripMenuItem.Click += new System.EventHandler(this.medianFilterToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.testToolStripMenuItem1.Text = "test";
            this.testToolStripMenuItem1.Click += new System.EventHandler(this.testToolStripMenuItem1_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // generatingSaltAndPepperToolStripMenuItem
            // 
            this.generatingSaltAndPepperToolStripMenuItem.Name = "generatingSaltAndPepperToolStripMenuItem";
            this.generatingSaltAndPepperToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.generatingSaltAndPepperToolStripMenuItem.Text = "Generating Salt and Pepper";
            this.generatingSaltAndPepperToolStripMenuItem.Click += new System.EventHandler(this.generatingSaltAndPepperToolStripMenuItem_Click);
            // 
            // negativeFilterToolStripMenuItem
            // 
            this.negativeFilterToolStripMenuItem.Name = "negativeFilterToolStripMenuItem";
            this.negativeFilterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.negativeFilterToolStripMenuItem.Text = "Negative Filter";
            this.negativeFilterToolStripMenuItem.Click += new System.EventHandler(this.negativeFilterToolStripMenuItem_Click);
            // 
            // 고주파강조ToolStripMenuItem
            // 
            this.고주파강조ToolStripMenuItem.Name = "고주파강조ToolStripMenuItem";
            this.고주파강조ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.고주파강조ToolStripMenuItem.Text = "High boost spatial filter";
            this.고주파강조ToolStripMenuItem.Click += new System.EventHandler(this.고주파강조ToolStripMenuItem_Click);
            // 
            // arithmeticalOperationToolStripMenuItem
            // 
            this.arithmeticalOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minusToolStripMenuItem});
            this.arithmeticalOperationToolStripMenuItem.Name = "arithmeticalOperationToolStripMenuItem";
            this.arithmeticalOperationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.arithmeticalOperationToolStripMenuItem.Text = "Arithmetical Operation";
            // 
            // minusToolStripMenuItem
            // 
            this.minusToolStripMenuItem.Name = "minusToolStripMenuItem";
            this.minusToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.minusToolStripMenuItem.Text = "Minus";
            this.minusToolStripMenuItem.Click += new System.EventHandler(this.minusToolStripMenuItem_Click);
            // 
            // mathmaticalMorphologyToolStripMenuItem
            // 
            this.mathmaticalMorphologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem,
            this.openningToolStripMenuItem,
            this.closingToolStripMenuItem});
            this.mathmaticalMorphologyToolStripMenuItem.Name = "mathmaticalMorphologyToolStripMenuItem";
            this.mathmaticalMorphologyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.mathmaticalMorphologyToolStripMenuItem.Text = "Mathmatical Morphology";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.dilationToolStripMenuItem.Text = "Dilation";
            this.dilationToolStripMenuItem.Click += new System.EventHandler(this.dilationToolStripMenuItem_Click);
            // 
            // openningToolStripMenuItem
            // 
            this.openningToolStripMenuItem.Name = "openningToolStripMenuItem";
            this.openningToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.openningToolStripMenuItem.Text = "Openning";
            this.openningToolStripMenuItem.Click += new System.EventHandler(this.openningToolStripMenuItem_Click);
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.closingToolStripMenuItem.Text = "Closing";
            this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downSamplingToolStripMenuItem,
            this.toolStripTextBox1});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.imageToolStripMenuItem.Text = "Image Compression";
            // 
            // downSamplingToolStripMenuItem
            // 
            this.downSamplingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downSamplingToolStripMenuItem1,
            this.interpolationCopyToolStripMenuItem,
            this.interpolationAverageToolStripMenuItem});
            this.downSamplingToolStripMenuItem.Name = "downSamplingToolStripMenuItem";
            this.downSamplingToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.downSamplingToolStripMenuItem.Text = "Down Sampling";
            // 
            // downSamplingToolStripMenuItem1
            // 
            this.downSamplingToolStripMenuItem1.Name = "downSamplingToolStripMenuItem1";
            this.downSamplingToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.downSamplingToolStripMenuItem1.Text = "Down Sampling";
            this.downSamplingToolStripMenuItem1.Click += new System.EventHandler(this.downSamplingToolStripMenuItem1_Click);
            // 
            // interpolationCopyToolStripMenuItem
            // 
            this.interpolationCopyToolStripMenuItem.Name = "interpolationCopyToolStripMenuItem";
            this.interpolationCopyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.interpolationCopyToolStripMenuItem.Text = "Interpolation(Copy)";
            this.interpolationCopyToolStripMenuItem.Click += new System.EventHandler(this.interpolationCopyToolStripMenuItem_Click);
            // 
            // interpolationAverageToolStripMenuItem
            // 
            this.interpolationAverageToolStripMenuItem.Name = "interpolationAverageToolStripMenuItem";
            this.interpolationAverageToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.interpolationAverageToolStripMenuItem.Text = "Interpolation(Average)";
            this.interpolationAverageToolStripMenuItem.Click += new System.EventHandler(this.interpolationAverageToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowBit0ToolStripMenuItem,
            this.lowBit8ToolStripMenuItem,
            this.randomLowBitToolStripMenuItem,
            this.truncationCodingToolStripMenuItem});
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(174, 22);
            this.toolStripTextBox1.Text = "Truncation Coding";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // lowBit0ToolStripMenuItem
            // 
            this.lowBit0ToolStripMenuItem.Name = "lowBit0ToolStripMenuItem";
            this.lowBit0ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lowBit0ToolStripMenuItem.Text = "LowBit-0";
            this.lowBit0ToolStripMenuItem.Click += new System.EventHandler(this.lowBit0ToolStripMenuItem_Click);
            // 
            // lowBit8ToolStripMenuItem
            // 
            this.lowBit8ToolStripMenuItem.Name = "lowBit8ToolStripMenuItem";
            this.lowBit8ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lowBit8ToolStripMenuItem.Text = "LowBit-8";
            this.lowBit8ToolStripMenuItem.Click += new System.EventHandler(this.lowBit8ToolStripMenuItem_Click);
            // 
            // randomLowBitToolStripMenuItem
            // 
            this.randomLowBitToolStripMenuItem.Name = "randomLowBitToolStripMenuItem";
            this.randomLowBitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.randomLowBitToolStripMenuItem.Text = "Random LowBit";
            this.randomLowBitToolStripMenuItem.Click += new System.EventHandler(this.randomLowBitToolStripMenuItem_Click);
            // 
            // truncationCodingToolStripMenuItem
            // 
            this.truncationCodingToolStripMenuItem.Name = "truncationCodingToolStripMenuItem";
            this.truncationCodingToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.truncationCodingToolStripMenuItem.Text = "Truncation Coding";
            this.truncationCodingToolStripMenuItem.Click += new System.EventHandler(this.truncationCodingToolStripMenuItem_Click);
            // 
            // quantizationToolStripMenuItem
            // 
            this.quantizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressToolStripMenuItem,
            this.decompressToolStripMenuItem,
            this.qunatizationToolStripMenuItem,
            this.reverseQuantizationToolStripMenuItem,
            this.setQuantizationLevelToolStripMenuItem,
            this.resetDCTObjectToolStripMenuItem});
            this.quantizationToolStripMenuItem.Name = "quantizationToolStripMenuItem";
            this.quantizationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.quantizationToolStripMenuItem.Text = "DCT";
            // 
            // compressToolStripMenuItem
            // 
            this.compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            this.compressToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.compressToolStripMenuItem.Text = "DCT";
            this.compressToolStripMenuItem.Click += new System.EventHandler(this.compressToolStripMenuItem_Click);
            // 
            // decompressToolStripMenuItem
            // 
            this.decompressToolStripMenuItem.Name = "decompressToolStripMenuItem";
            this.decompressToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.decompressToolStripMenuItem.Text = "Reverse DCT";
            this.decompressToolStripMenuItem.Click += new System.EventHandler(this.decompressToolStripMenuItem_Click);
            // 
            // qunatizationToolStripMenuItem
            // 
            this.qunatizationToolStripMenuItem.Name = "qunatizationToolStripMenuItem";
            this.qunatizationToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.qunatizationToolStripMenuItem.Text = "Qunatization";
            this.qunatizationToolStripMenuItem.Click += new System.EventHandler(this.qunatizationToolStripMenuItem_Click);
            // 
            // reverseQuantizationToolStripMenuItem
            // 
            this.reverseQuantizationToolStripMenuItem.Name = "reverseQuantizationToolStripMenuItem";
            this.reverseQuantizationToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.reverseQuantizationToolStripMenuItem.Text = "Reverse Quantization";
            this.reverseQuantizationToolStripMenuItem.Click += new System.EventHandler(this.reverseQuantizationToolStripMenuItem_Click);
            // 
            // setQuantizationLevelToolStripMenuItem
            // 
            this.setQuantizationLevelToolStripMenuItem.Name = "setQuantizationLevelToolStripMenuItem";
            this.setQuantizationLevelToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.setQuantizationLevelToolStripMenuItem.Text = "Set Quantization Level";
            this.setQuantizationLevelToolStripMenuItem.Click += new System.EventHandler(this.setQuantizationLevelToolStripMenuItem_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(591, 58);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(500, 500);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resultPictureBox.TabIndex = 8;
            this.resultPictureBox.TabStop = false;
            this.resultPictureBox.Click += new System.EventHandler(this.resultPictureBox_Click);
            // 
            // resultAdjustButton
            // 
            this.resultAdjustButton.Location = new System.Drawing.Point(512, 247);
            this.resultAdjustButton.Name = "resultAdjustButton";
            this.resultAdjustButton.Size = new System.Drawing.Size(75, 23);
            this.resultAdjustButton.TabIndex = 9;
            this.resultAdjustButton.Text = "<<<<<<<<<";
            this.resultAdjustButton.UseVisualStyleBackColor = true;
            this.resultAdjustButton.Click += new System.EventHandler(this.resultAdjustButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = ">>>>>>>>>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 566);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Clear MainPictureBox";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(939, 564);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Clear ResultPictureBox";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // resetDCTObjectToolStripMenuItem
            // 
            this.resetDCTObjectToolStripMenuItem.Name = "resetDCTObjectToolStripMenuItem";
            this.resetDCTObjectToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.resetDCTObjectToolStripMenuItem.Text = "Reset DCT Object";
            this.resetDCTObjectToolStripMenuItem.Click += new System.EventHandler(this.resetDCTObjectToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1096, 601);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultAdjustButton);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.OpenedFileList);
            this.Controls.Add(this.MainPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Digital Image Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox OpenedFileList;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiSaveSaveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerGraphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitalImageProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineDrawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDALineDrawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamMidpointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleDrawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamMidpointCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arithmeticalOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowpassFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highpassFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 고주파강조ToolStripMenuItem;
        protected internal System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        protected internal System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.Button resultAdjustButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem negativeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatingSaltAndPepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem report02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureRotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleNRectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triagleMoveNRoateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mathmaticalMorphologyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bezierCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downSamplingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downSamplingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem interpolationCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interpolationAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem lowBit0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowBit8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomLowBitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncationCodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quantizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qunatizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseQuantizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setQuantizationLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDCTObjectToolStripMenuItem;
    }
}


