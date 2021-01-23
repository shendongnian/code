    public partial class Form1 : Form
    {
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        System.Windows.Forms.Timer ToolTipsTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            ToolTipsTimer.Tick += new EventHandler(ToolTipsTimerEventProcessor);
            ToolTipsTimer.Interval = 300;
            ToolTipsTimer.Start();
            toolTip1.AutomaticDelay = 300;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void ToolTipsTimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            ToolTipsTimer.Enabled = false;
        }
        string TextString = "First line\n Second line";
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ToolTipsTimer.Enabled)
            {
                toolTip1.SetToolTip(pictureBox1, TextString);
                ToolTipsTimer.Enabled = true;
            }
        }
    }
