    namespace Offloading_Calculator
{
    public partial class Main_Form : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Main_Form()
        {
            InitializeComponent();
        }
        
        private void Label_Xbutton_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            if (MessageBox.Show("Do you want to exit?", "Saying Goodbye already?",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Label1_Xbutton_MouseEnter(object sender, EventArgs e)
        {
            Label_Xbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(44)))), ((int)(((byte)(7)))));
        }
        private void Label1_Xbutton_MouseLeave(object sender, EventArgs e)
        {
            Label_Xbutton.BackColor = System.Drawing.Color.Transparent;
        }
        private void Label_MinimizeBUtton_MouseEnter(object sender, EventArgs e)
        {
            Label_MinimizeBUtton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(44)))), ((int)(((byte)(7)))));
        }
        private void Label_MinimizeBUtton_MouseLeave(object sender, EventArgs e)
        {
            Label_MinimizeBUtton.BackColor = System.Drawing.Color.Transparent;
        }
        private void Label_MinimizeBUtton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
       
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Height == 680)
            {
                panel2.Height = 45;
            }
            else
            {
                panel2.Height = 680;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //var Form2 = new Form2();
            //Form2.Show();
            //button1.Enabled = false;
            Form2 f2 = new Form2(this)
        }
        public void ChangeButtonStatus()
        {
            this.button1.Enabled = !this.button1.Enabled;
        }
    }
