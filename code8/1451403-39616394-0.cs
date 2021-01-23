    public partial class UC_ToolTipButton : UserControl
    {
        public string TT_FontFamily { get; set; }
        public float TT_FontSize { get; set; }
        public string TT_Message
        {
            get
            {
                return ToolTip_Message.GetToolTip(btnTT);
            }
            set
            {
                ToolTip_Message.SetToolTip(btnTT, value);
            }
        }
        public UC_ToolTipButton()
        {
            InitializeComponent();
            TT_FontFamily = "Tahoma";
            TT_FontSize = 10;
            ToolTip_Message.OwnerDraw = true;
            ToolTip_Message.Draw += new DrawToolTipEventHandler(TT_Draw);
            ToolTip_Message.Popup += new PopupEventHandler(TT_Popup);
        }
        private void TT_Popup(object sender, PopupEventArgs e)
        {
            using (Font f = new Font(TT_FontFamily, TT_FontSize))
            {
                e.ToolTipSize = TextRenderer.MeasureText(ToolTip_Message.GetToolTip(e.AssociatedControl), f);
            }
        }
        private void TT_Draw(System.Object sender,
            System.Windows.Forms.DrawToolTipEventArgs e)
        {
                e.DrawBackground();
                e.DrawBorder();
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    using (Font f = new Font(TT_FontFamily, TT_FontSize))
                    {
                        e.Graphics.DrawString(e.ToolTipText, f, SystemBrushes.ActiveCaptionText, e.Bounds, sf);
                    }
                }
        }
    }
