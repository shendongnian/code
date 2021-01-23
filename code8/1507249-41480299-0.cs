    using System.Drawing;
    using System.Windows.Forms;
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //for a custom paint control, calculate the minimum size which needs scrollbars
            //for a normal container control you don't need to calculate minimum size
            this.AutoScrollMinSize = new Size(300, 500); 
            base.OnPaint(e);
            var r = this.DisplayRectangle;
            r.Width--; r.Height--;
            e.Graphics.DrawRectangle(Pens.Red, r);
            TextRenderer.DrawText(e.Graphics, "Top-Left", Font, r, ForeColor, 
                TextFormatFlags.Top | TextFormatFlags.Left);
            TextRenderer.DrawText(e.Graphics, "Bottom-Right", Font, r, ForeColor, 
                TextFormatFlags.Bottom | TextFormatFlags.Right);
        }
    }
