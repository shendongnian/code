    namespace Offloading_Calculator
{
    public partial class Form2 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        
        public object Form1 { get; private set; }
        public Form1 internalForm1 { get; private set; }
        public Form2(Form1 f1) : this()
        {
            internalForm1 = f1;
        }
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Form2()
        {
            InitializeComponent();
            
        }
        private void Label_XButton2_Click(object sender, EventArgs e)
        {
            internalForm1.ChangeButtonStatus();
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
