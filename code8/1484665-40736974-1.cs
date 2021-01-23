    public partial class MyRichEdit : RichTextBox
    {
        public MyRichEdit()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case 15://WM_PAINT
                    base.WndProc(ref msg);
                    Graphics g = Graphics.FromHwnd(Handle);
                    Pen pen = new Pen(Color.Red);
                    g.DrawRectangle(pen, 0, 0, 10, 10);
                    return;
            }
            base.WndProc(ref msg);
        }
    }
