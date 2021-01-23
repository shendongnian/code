    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
    
        private Point MouseDownLocation;
    
    
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
    
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                btn.Left = e.X + btn.Left - MouseDownLocation.X;
                btn.Top = e.Y + btn.Top - MouseDownLocation.Y;
            }
        }
    
    }
