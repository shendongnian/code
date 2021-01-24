    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool moving;
        Point offset;
        Point original;
    
        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            panel1.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }
        void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;
            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;
            this.Location = new Point(x, y);
        }
        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            panel1.Capture = false;
        }
    }
