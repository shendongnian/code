    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
    
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);;
            Graphics cg = Graphics.FromImage(bmp);
    
            // your other code from timer1_Tick
            // Get components of the DateTime
            DateTime DateTimenow = DateTime.Now;
            double hour = DateTimenow.Hour;
            double minute = DateTimenow.Minute;
            double second = DateTimenow.Second;
            // ....
            pictureBox1.Image = bmp;
            cg.Dispose();
        }
    }
