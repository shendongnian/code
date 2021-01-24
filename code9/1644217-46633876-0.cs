    using System.Windows.Forms;
    public class TransparentPanel : Panel
    {
        const int WS_EX_TRANSPARENT = 0x20;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
