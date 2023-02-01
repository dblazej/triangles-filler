namespace TrianglesFiller
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.lightGroupBox = new System.Windows.Forms.GroupBox();
            this.showTrianglesCheckBox = new System.Windows.Forms.CheckBox();
            this.selectLightColorButton = new System.Windows.Forms.Button();
            this.animationButton = new System.Windows.Forms.Button();
            this.zGroupBox = new System.Windows.Forms.GroupBox();
            this.zLabel = new System.Windows.Forms.Label();
            this.zTrackBar = new System.Windows.Forms.TrackBar();
            this.tfcGroupBox = new System.Windows.Forms.GroupBox();
            this.pointRadioButton = new System.Windows.Forms.RadioButton();
            this.verticesRadioButton = new System.Windows.Forms.RadioButton();
            this.surfaceGroupBox = new System.Windows.Forms.GroupBox();
            this.modifyVectorsCheckBox = new System.Windows.Forms.CheckBox();
            this.loadTextureButton = new System.Windows.Forms.Button();
            this.selectSurfaceColorButton = new System.Windows.Forms.Button();
            this.loadSurfaceButton = new System.Windows.Forms.Button();
            this.textureRadioButton = new System.Windows.Forms.RadioButton();
            this.colorRadioButton = new System.Windows.Forms.RadioButton();
            this.kdGroupBox = new System.Windows.Forms.GroupBox();
            this.kdLabel = new System.Windows.Forms.Label();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.ksGroupBox = new System.Windows.Forms.GroupBox();
            this.ksLabel = new System.Windows.Forms.Label();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.mGroupBox = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.lightGroupBox.SuspendLayout();
            this.zGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
            this.tfcGroupBox.SuspendLayout();
            this.surfaceGroupBox.SuspendLayout();
            this.kdGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.ksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            this.mGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(30, 34);
            this.canvas.MaximumSize = new System.Drawing.Size(500, 500);
            this.canvas.MinimumSize = new System.Drawing.Size(500, 500);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 500);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // lightGroupBox
            // 
            this.lightGroupBox.Controls.Add(this.showTrianglesCheckBox);
            this.lightGroupBox.Controls.Add(this.selectLightColorButton);
            this.lightGroupBox.Controls.Add(this.animationButton);
            this.lightGroupBox.Controls.Add(this.zGroupBox);
            this.lightGroupBox.Location = new System.Drawing.Point(568, 12);
            this.lightGroupBox.Name = "lightGroupBox";
            this.lightGroupBox.Size = new System.Drawing.Size(279, 122);
            this.lightGroupBox.TabIndex = 1;
            this.lightGroupBox.TabStop = false;
            this.lightGroupBox.Text = "Light";
            // 
            // showTrianglesCheckBox
            // 
            this.showTrianglesCheckBox.AutoSize = true;
            this.showTrianglesCheckBox.Location = new System.Drawing.Point(10, 85);
            this.showTrianglesCheckBox.Name = "showTrianglesCheckBox";
            this.showTrianglesCheckBox.Size = new System.Drawing.Size(104, 19);
            this.showTrianglesCheckBox.TabIndex = 10;
            this.showTrianglesCheckBox.Text = "Show Triangles";
            this.showTrianglesCheckBox.UseVisualStyleBackColor = true;
            this.showTrianglesCheckBox.CheckedChanged += new System.EventHandler(this.ShowTrianglesCheckBox_CheckedChanged);
            // 
            // selectLightColorButton
            // 
            this.selectLightColorButton.Location = new System.Drawing.Point(99, 22);
            this.selectLightColorButton.Name = "selectLightColorButton";
            this.selectLightColorButton.Size = new System.Drawing.Size(75, 42);
            this.selectLightColorButton.TabIndex = 9;
            this.selectLightColorButton.Text = "Select Color";
            this.selectLightColorButton.UseVisualStyleBackColor = true;
            this.selectLightColorButton.Click += new System.EventHandler(this.SelectLightColorButton_Click);
            // 
            // animationButton
            // 
            this.animationButton.BackColor = System.Drawing.Color.LawnGreen;
            this.animationButton.Location = new System.Drawing.Point(10, 22);
            this.animationButton.Name = "animationButton";
            this.animationButton.Size = new System.Drawing.Size(75, 42);
            this.animationButton.TabIndex = 8;
            this.animationButton.Text = "Animation";
            this.animationButton.UseVisualStyleBackColor = false;
            this.animationButton.Click += new System.EventHandler(this.AnimationButton_Click);
            // 
            // zGroupBox
            // 
            this.zGroupBox.Controls.Add(this.zLabel);
            this.zGroupBox.Controls.Add(this.zTrackBar);
            this.zGroupBox.Location = new System.Drawing.Point(186, 13);
            this.zGroupBox.Name = "zGroupBox";
            this.zGroupBox.Size = new System.Drawing.Size(83, 103);
            this.zGroupBox.TabIndex = 7;
            this.zGroupBox.TabStop = false;
            this.zGroupBox.Text = "Z";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.zLabel.Location = new System.Drawing.Point(12, 61);
            this.zLabel.MaximumSize = new System.Drawing.Size(65, 30);
            this.zLabel.MinimumSize = new System.Drawing.Size(65, 30);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(65, 30);
            this.zLabel.TabIndex = 1;
            this.zLabel.Text = "270";
            this.zLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zTrackBar
            // 
            this.zTrackBar.Location = new System.Drawing.Point(6, 22);
            this.zTrackBar.Maximum = 300;
            this.zTrackBar.Minimum = 240;
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(71, 45);
            this.zTrackBar.TabIndex = 0;
            this.zTrackBar.TickFrequency = 2;
            this.zTrackBar.Value = 270;
            this.zTrackBar.Scroll += new System.EventHandler(this.ZTrackBar_Scroll);
            // 
            // tfcGroupBox
            // 
            this.tfcGroupBox.Controls.Add(this.pointRadioButton);
            this.tfcGroupBox.Controls.Add(this.verticesRadioButton);
            this.tfcGroupBox.Location = new System.Drawing.Point(568, 268);
            this.tfcGroupBox.Name = "tfcGroupBox";
            this.tfcGroupBox.Size = new System.Drawing.Size(279, 50);
            this.tfcGroupBox.TabIndex = 3;
            this.tfcGroupBox.TabStop = false;
            this.tfcGroupBox.Text = "Triangles Fill Color";
            // 
            // pointRadioButton
            // 
            this.pointRadioButton.AutoSize = true;
            this.pointRadioButton.Location = new System.Drawing.Point(165, 22);
            this.pointRadioButton.Name = "pointRadioButton";
            this.pointRadioButton.Size = new System.Drawing.Size(53, 19);
            this.pointRadioButton.TabIndex = 1;
            this.pointRadioButton.Text = "Point";
            this.pointRadioButton.UseVisualStyleBackColor = true;
            this.pointRadioButton.CheckedChanged += new System.EventHandler(this.PointRadioButton_CheckedChanged);
            // 
            // verticesRadioButton
            // 
            this.verticesRadioButton.AutoSize = true;
            this.verticesRadioButton.Checked = true;
            this.verticesRadioButton.Location = new System.Drawing.Point(20, 22);
            this.verticesRadioButton.Name = "verticesRadioButton";
            this.verticesRadioButton.Size = new System.Drawing.Size(65, 19);
            this.verticesRadioButton.TabIndex = 0;
            this.verticesRadioButton.TabStop = true;
            this.verticesRadioButton.Text = "Vertices";
            this.verticesRadioButton.UseVisualStyleBackColor = true;
            this.verticesRadioButton.CheckedChanged += new System.EventHandler(this.VerticesRadioButton_CheckedChanged);
            // 
            // surfaceGroupBox
            // 
            this.surfaceGroupBox.Controls.Add(this.modifyVectorsCheckBox);
            this.surfaceGroupBox.Controls.Add(this.loadTextureButton);
            this.surfaceGroupBox.Controls.Add(this.selectSurfaceColorButton);
            this.surfaceGroupBox.Controls.Add(this.loadSurfaceButton);
            this.surfaceGroupBox.Controls.Add(this.textureRadioButton);
            this.surfaceGroupBox.Controls.Add(this.colorRadioButton);
            this.surfaceGroupBox.Location = new System.Drawing.Point(568, 140);
            this.surfaceGroupBox.Name = "surfaceGroupBox";
            this.surfaceGroupBox.Size = new System.Drawing.Size(279, 122);
            this.surfaceGroupBox.TabIndex = 4;
            this.surfaceGroupBox.TabStop = false;
            this.surfaceGroupBox.Text = "Surface";
            // 
            // modifyVectorsCheckBox
            // 
            this.modifyVectorsCheckBox.AutoSize = true;
            this.modifyVectorsCheckBox.Location = new System.Drawing.Point(10, 89);
            this.modifyVectorsCheckBox.Name = "modifyVectorsCheckBox";
            this.modifyVectorsCheckBox.Size = new System.Drawing.Size(105, 19);
            this.modifyVectorsCheckBox.TabIndex = 5;
            this.modifyVectorsCheckBox.Text = "Modify vectors";
            this.modifyVectorsCheckBox.UseVisualStyleBackColor = true;
            this.modifyVectorsCheckBox.CheckedChanged += new System.EventHandler(this.ModifyVectorsCheckBox_CheckedChanged);
            // 
            // loadTextureButton
            // 
            this.loadTextureButton.Location = new System.Drawing.Point(194, 28);
            this.loadTextureButton.Name = "loadTextureButton";
            this.loadTextureButton.Size = new System.Drawing.Size(75, 42);
            this.loadTextureButton.TabIndex = 4;
            this.loadTextureButton.Text = "Load Texture";
            this.loadTextureButton.UseVisualStyleBackColor = true;
            this.loadTextureButton.Click += new System.EventHandler(this.LoadTextureButton_Click);
            // 
            // selectSurfaceColorButton
            // 
            this.selectSurfaceColorButton.BackColor = System.Drawing.Color.DarkOrange;
            this.selectSurfaceColorButton.Location = new System.Drawing.Point(105, 28);
            this.selectSurfaceColorButton.Name = "selectSurfaceColorButton";
            this.selectSurfaceColorButton.Size = new System.Drawing.Size(75, 42);
            this.selectSurfaceColorButton.TabIndex = 3;
            this.selectSurfaceColorButton.Text = "Select Color";
            this.selectSurfaceColorButton.UseVisualStyleBackColor = false;
            this.selectSurfaceColorButton.Click += new System.EventHandler(this.SelectSurfaceColorButton_Click);
            // 
            // loadSurfaceButton
            // 
            this.loadSurfaceButton.Enabled = false;
            this.loadSurfaceButton.Location = new System.Drawing.Point(10, 28);
            this.loadSurfaceButton.Name = "loadSurfaceButton";
            this.loadSurfaceButton.Size = new System.Drawing.Size(75, 42);
            this.loadSurfaceButton.TabIndex = 2;
            this.loadSurfaceButton.Text = "Load Surface";
            this.loadSurfaceButton.UseVisualStyleBackColor = true;
            this.loadSurfaceButton.Click += new System.EventHandler(this.LoadSurfaceButton_Click);
            // 
            // textureRadioButton
            // 
            this.textureRadioButton.AutoSize = true;
            this.textureRadioButton.Enabled = false;
            this.textureRadioButton.Location = new System.Drawing.Point(206, 88);
            this.textureRadioButton.Name = "textureRadioButton";
            this.textureRadioButton.Size = new System.Drawing.Size(63, 19);
            this.textureRadioButton.TabIndex = 1;
            this.textureRadioButton.Text = "Texture";
            this.textureRadioButton.UseVisualStyleBackColor = true;
            this.textureRadioButton.CheckedChanged += new System.EventHandler(this.TextureRadioButton_CheckedChanged);
            // 
            // colorRadioButton
            // 
            this.colorRadioButton.AutoSize = true;
            this.colorRadioButton.Checked = true;
            this.colorRadioButton.Location = new System.Drawing.Point(126, 88);
            this.colorRadioButton.Name = "colorRadioButton";
            this.colorRadioButton.Size = new System.Drawing.Size(54, 19);
            this.colorRadioButton.TabIndex = 0;
            this.colorRadioButton.TabStop = true;
            this.colorRadioButton.Text = "Color";
            this.colorRadioButton.UseVisualStyleBackColor = true;
            this.colorRadioButton.CheckedChanged += new System.EventHandler(this.ColorRadioButton_CheckedChanged);
            // 
            // kdGroupBox
            // 
            this.kdGroupBox.Controls.Add(this.kdLabel);
            this.kdGroupBox.Controls.Add(this.kdTrackBar);
            this.kdGroupBox.Location = new System.Drawing.Point(568, 324);
            this.kdGroupBox.Name = "kdGroupBox";
            this.kdGroupBox.Size = new System.Drawing.Size(133, 113);
            this.kdGroupBox.TabIndex = 5;
            this.kdGroupBox.TabStop = false;
            this.kdGroupBox.Text = "Kd";
            // 
            // kdLabel
            // 
            this.kdLabel.AutoSize = true;
            this.kdLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kdLabel.Location = new System.Drawing.Point(20, 80);
            this.kdLabel.MaximumSize = new System.Drawing.Size(100, 30);
            this.kdLabel.MinimumSize = new System.Drawing.Size(100, 30);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(100, 30);
            this.kdLabel.TabIndex = 1;
            this.kdLabel.Text = "0.5";
            this.kdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Location = new System.Drawing.Point(15, 32);
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kdTrackBar.TabIndex = 0;
            this.kdTrackBar.Value = 5;
            this.kdTrackBar.Scroll += new System.EventHandler(this.KdTrackBar_Scroll);
            // 
            // ksGroupBox
            // 
            this.ksGroupBox.Controls.Add(this.ksLabel);
            this.ksGroupBox.Controls.Add(this.ksTrackBar);
            this.ksGroupBox.Location = new System.Drawing.Point(714, 324);
            this.ksGroupBox.Name = "ksGroupBox";
            this.ksGroupBox.Size = new System.Drawing.Size(133, 113);
            this.ksGroupBox.TabIndex = 6;
            this.ksGroupBox.TabStop = false;
            this.ksGroupBox.Text = "Ks";
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ksLabel.Location = new System.Drawing.Point(20, 80);
            this.ksLabel.MaximumSize = new System.Drawing.Size(100, 30);
            this.ksLabel.MinimumSize = new System.Drawing.Size(100, 30);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(100, 30);
            this.ksLabel.TabIndex = 1;
            this.ksLabel.Text = "0.5";
            this.ksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Location = new System.Drawing.Point(15, 32);
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ksTrackBar.TabIndex = 0;
            this.ksTrackBar.Value = 5;
            this.ksTrackBar.Scroll += new System.EventHandler(this.KsTrackBar_Scroll);
            // 
            // mGroupBox
            // 
            this.mGroupBox.Controls.Add(this.mLabel);
            this.mGroupBox.Controls.Add(this.mTrackBar);
            this.mGroupBox.Location = new System.Drawing.Point(568, 449);
            this.mGroupBox.Name = "mGroupBox";
            this.mGroupBox.Size = new System.Drawing.Size(133, 113);
            this.mGroupBox.TabIndex = 7;
            this.mGroupBox.TabStop = false;
            this.mGroupBox.Text = "M";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mLabel.Location = new System.Drawing.Point(20, 80);
            this.mLabel.MaximumSize = new System.Drawing.Size(100, 30);
            this.mLabel.MinimumSize = new System.Drawing.Size(100, 30);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(100, 30);
            this.mLabel.TabIndex = 1;
            this.mLabel.Text = "50";
            this.mLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mTrackBar
            // 
            this.mTrackBar.Location = new System.Drawing.Point(15, 32);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(104, 45);
            this.mTrackBar.TabIndex = 0;
            this.mTrackBar.TickFrequency = 10;
            this.mTrackBar.Value = 50;
            this.mTrackBar.Scroll += new System.EventHandler(this.MTrackBar_Scroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 571);
            this.Controls.Add(this.mGroupBox);
            this.Controls.Add(this.ksGroupBox);
            this.Controls.Add(this.kdGroupBox);
            this.Controls.Add(this.surfaceGroupBox);
            this.Controls.Add(this.tfcGroupBox);
            this.Controls.Add(this.lightGroupBox);
            this.Controls.Add(this.canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(875, 610);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(875, 610);
            this.Name = "MainWindow";
            this.Text = "Triangles Filler";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.lightGroupBox.ResumeLayout(false);
            this.lightGroupBox.PerformLayout();
            this.zGroupBox.ResumeLayout(false);
            this.zGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
            this.tfcGroupBox.ResumeLayout(false);
            this.tfcGroupBox.PerformLayout();
            this.surfaceGroupBox.ResumeLayout(false);
            this.surfaceGroupBox.PerformLayout();
            this.kdGroupBox.ResumeLayout(false);
            this.kdGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.ksGroupBox.ResumeLayout(false);
            this.ksGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            this.mGroupBox.ResumeLayout(false);
            this.mGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox canvas;
        private GroupBox lightGroupBox;
        private GroupBox tfcGroupBox;
        private RadioButton pointRadioButton;
        private RadioButton verticesRadioButton;
        private GroupBox surfaceGroupBox;
        private Button loadTextureButton;
        private Button selectSurfaceColorButton;
        private Button loadSurfaceButton;
        private RadioButton textureRadioButton;
        private RadioButton colorRadioButton;
        private GroupBox kdGroupBox;
        private Label kdLabel;
        private TrackBar kdTrackBar;
        private GroupBox zGroupBox;
        private Label zLabel;
        private TrackBar zTrackBar;
        private GroupBox ksGroupBox;
        private Label ksLabel;
        private TrackBar ksTrackBar;
        private GroupBox mGroupBox;
        private Label mLabel;
        private TrackBar mTrackBar;
        private Button selectLightColorButton;
        private Button animationButton;
        private CheckBox showTrianglesCheckBox;
        private CheckBox modifyVectorsCheckBox;
    }
}