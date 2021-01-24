    public class KeyInput : UserControl
    {
        public string KeyString { get; set; } = "HELLO";
        public KeyInput() : base()
        {
            BorderStyle = BorderStyle.Fixed3D;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            KeyString = e.KeyChar.ToString();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(KeyString, Font, SystemBrushes.ControlText, 0, 0);
        }
    }
