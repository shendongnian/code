    public partial class MyRichEdit : RichTextBox
    {
        public MyRichEdit()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 15)//WM_PAINT = 15
            {
                base.WndProc(ref m);
                Graphics g = Graphics.FromHwnd(Handle);
                SolidBrush brush = new SolidBrush(Color.Black);
                g.DrawString("Test", SystemFonts.DefaultFont, brush, 0, 0);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
