    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += CapsLockMonitor;
            this.KeyPreview = true;
        }
        private void CapsLockMonitor(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                this.label1.Text = "Caps lock enabled!";
            }
            else
            {
                this.label1.Text = "Caps lock disabled!";
            }
        }
    }
