    public partial class ScalingCircle : Form
    {
        public Graphics DeviceContexct;
        // current transformation matrix of main view (offset & scaling)
        public Matrix mainViewTransform = new Matrix();
        public int scale = 1;
        public ScalingCircle()
        {
            InitializeComponent();
            DeviceContexct = Graphics.FromHwnd(this.Handle);
            DeviceContexct = this.CreateGraphics();
        }
        public void ScalingCircle_Paint(object sender, PaintEventArgs e)
        {
            DeviceContexct = e.Graphics;
            DeviceContexct.PageUnit = GraphicsUnit.Pixel;
            DeviceContexct.Transform = mainViewTransform;
            ScalingCircle1(scale);
        }
        private void ScalingCircle1(int x )
        {
            Pen myPen2 = new Pen(Color.Black, 1);
            DeviceContexct.Transform = mainViewTransform;
       
            Rectangle myRectangle = new Rectangle(50, 50, 100 * x, 100 * x);
            DeviceContexct.FillRectangle(new SolidBrush(Color.BurlyWood), myRectangle);
        }
        private void ScalingCircle_Load( object sender, EventArgs e )
        {
            this.ResizeRedraw = true;
          }
        private void button1_Click( object sender, EventArgs e )
        {
            scale += 5;
            this.Refresh();
        }
        private void button2_Click( object sender, EventArgs e )
        {
            if (scale > 1)
            {
                scale -= 5;
                this.Refresh();
            }
        }
    }
