    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const uint EM_SETCUEBANNER = 0x1501;
        private const uint CB_SETCUEBANNER = 0x1703;
        public Form1()
        {
            InitializeComponent();
            //Text that will appear in the textbox if it is empty
            setCueText(textBox1, "Enter password here");
        }
        private void setCueText(Control ctl, string text)
        {
            if (ctl is ComboBox)
            {
                SendMessage(ctl.Handle, CB_SETCUEBANNER, (IntPtr)0, text);
            }
            else
            {
                SendMessage(ctl.Handle, EM_SETCUEBANNER, (IntPtr)0, text);
            }
        }
    }
