namespace TrianglesFiller
{
    public partial class MainWindow : Form
    {
        public static Point3D center = new() { X = 250, Y = 250, Z = 250 };
        private Point light = new();
        private readonly Surface? surface;
        public static Color LightColor = Color.White;
        public static Color SurfaceSolidColor = Color.DarkOrange;
        public static int surfaceRadius = 240;
        public static int canvasWidth = 500;
        public static int canvasHeight = 500;
        public static int LightZ = 270;
        public static double Kd = 0.5;
        public static double Ks = 0.5;
        public static int M = 50;
        private readonly System.Timers.Timer timer;
        private double dAlfa = 0;
        private double r = 0;
        private double animationSpeed = 3;
        public static bool texture = false;
        public static bool textureReady = false;
        public static bool modifyVectorsOn = false;
        bool animation = true;
        bool trianglesVisible = false;
        bool vertices = true;

        public MainWindow()
        {
            InitializeComponent();

            canvasWidth = this.canvas.Width;
            canvasHeight = this.canvas.Height;
            surface = new Surface(new Point3D() { X = canvasWidth / 2, Y = canvasHeight / 2, Z = 0 }, surfaceRadius);
            surface.Triangulation();

            timer = new System.Timers.Timer
            {
                Interval = 20
            };
            timer.Elapsed += Animate;
            timer.Enabled = true;

            this.canvas.Image = new System.Drawing.Bitmap(this.canvas.Width, this.canvas.Height);
        }
        private void Animate(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (animation)
            {
                this.dAlfa += animationSpeed * 0.025;
                if (this.r > 400 || this.r < 0) this.animationSpeed = -this.animationSpeed;
                this.r += this.animationSpeed;
                this.light.X = (int)(this.r * Math.Cos(this.dAlfa) + this.canvas.Width / 2);
                this.light.Y = (int)(this.r * Math.Sin(this.dAlfa) + this.canvas.Height / 2);
                this.canvas.Invalidate();
            }
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            using FastBitmap bm = new(this.canvas.Width, this.canvas.Height);
            if (this.surface == null) return;
            this.surface.Draw(e, bm, this.light, trianglesVisible, vertices);
            e.Graphics.DrawImage(bm.GetBitmap(), 0, 0);
        }
        private void AnimationButton_Click(object sender, EventArgs e)
        {
            if(animation)
            {
                animation = false;
                this.animationButton.BackColor = Color.Red;
            }
            else
            {
                animation = true;
                this.animationButton.BackColor = Color.LawnGreen;
            }
            this.canvas.Invalidate();
        }
        private void SelectLightColorButton_Click(object sender, EventArgs e)
        {
            bool animationCurrentState = animation;
            animation = false;
            if (animationCurrentState) this.animationButton.BackColor = Color.Red;
            ColorDialog MyDialog = new()
            {
                AllowFullOpen = false,
                ShowHelp = true,
                Color = selectLightColorButton.BackColor
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                selectLightColorButton.BackColor = MyDialog.Color;
                LightColor = MyDialog.Color;
                selectLightColorButton.ForeColor = ((MyDialog.Color.R * 299 + MyDialog.Color.G * 587 + MyDialog.Color.B * 114) / 1000) < 128 ? Color.White : Color.Black;
            }
            animation = animationCurrentState;
            if(animation) this.animationButton.BackColor = Color.LawnGreen;
            this.canvas.Invalidate();
        }
        private void ZTrackBar_Scroll(object sender, EventArgs e)
        {
            LightZ = this.zTrackBar.Value;
            this.zLabel.Text = LightZ.ToString();
            this.canvas.Invalidate();
        }
        private void LoadSurfaceButton_Click(object sender, EventArgs e)
        {
        }
        private void SelectSurfaceColorButton_Click(object sender, EventArgs e)
        {
            bool animationCurrentState = animation;
            animation = false;
            if(animationCurrentState) this.animationButton.BackColor = Color.Red;
            ColorDialog MyDialog = new()
            {
                AllowFullOpen = false,
                ShowHelp = true,
                Color = selectSurfaceColorButton.BackColor
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                selectSurfaceColorButton.BackColor = MyDialog.Color;
                SurfaceSolidColor = MyDialog.Color;
                selectSurfaceColorButton.ForeColor = ((MyDialog.Color.R * 299 + MyDialog.Color.G * 587 + MyDialog.Color.B * 114) / 1000) < 128 ? Color.White : Color.Black;
            }
            animation = animationCurrentState;
            if(animation) this.animationButton.BackColor = Color.LawnGreen;
            this.canvas.Invalidate();
        }
        private void LoadTextureButton_Click(object sender, EventArgs e)
        {
            bool animationCurrentState = animation;
            animation = false;
            if (animationCurrentState) this.animationButton.BackColor = Color.Red;

            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetParent(Directory.GetParent(workingDirectory).Parent.FullName).FullName + "\\Textures",
                Filter = "Image Files(*.PNG;*.JPG;*.BMP;*.GIF)|*.PNG;*.JPG;*.BMP;*.GIF|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) this.LoadTexture(openFileDialog.FileName);

            animation = animationCurrentState;
            if (animation) this.animationButton.BackColor = Color.LawnGreen;
            this.canvas.Invalidate();
        }

        private void LoadTexture(string? texturePath = null)
        {
            textureReady = false;

        }
        private void ColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void TextureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void VerticesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            vertices = true;
            this.canvas.Invalidate();
        }
        private void PointRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            vertices = false;
            this.canvas.Invalidate();
        }
        private void KdTrackBar_Scroll(object sender, EventArgs e)
        {
            MainWindow.Kd = this.kdTrackBar.Value * 0.1;
            if (MainWindow.Kd == 0 || MainWindow.Kd == 1) this.kdLabel.Text = MainWindow.Kd.ToString();
            else this.kdLabel.Text = MainWindow.Kd.ToString()[..3];
            this.canvas.Invalidate();
        }
        private void KsTrackBar_Scroll(object sender, EventArgs e)
        {
            MainWindow.Ks = this.ksTrackBar.Value * 0.1;
            if (MainWindow.Ks == 0 || MainWindow.Ks == 1) this.ksLabel.Text = MainWindow.Ks.ToString();
            else this.ksLabel.Text = MainWindow.Ks.ToString()[..3];
            this.canvas.Invalidate();
        }
        private void MTrackBar_Scroll(object sender, EventArgs e)
        {
            MainWindow.M = this.mTrackBar.Value;
            this.mLabel.Text = MainWindow.M.ToString();
            this.canvas.Invalidate();
        }

        private void ShowTrianglesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(showTrianglesCheckBox.Checked) 
            {
                trianglesVisible = true;
                animationButton.Enabled = false;
                if(animation)
                {
                    animation = false;
                    animationButton.BackColor = Color.Red;
                }
            }
            else
            {
                trianglesVisible = false;
                animationButton.Enabled = true;
            }
            this.canvas.Invalidate();
        }

        private void ModifyVectorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}