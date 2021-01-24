    namespace WindowsFormsApplication1 {
    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            using (Font f1 = new Font("Wingdings", 12))
            using (Font f2 = new Font(Font.Name, Font.Size)) {
                TextRenderer.DrawText(e.Graphics, "à", f1, new Point(10, 10), Color.Black);
                TextRenderer.DrawText(e.Graphics, "à", Font, new Point(30, 10), Color.Black);
                TextRenderer.DrawText(e.Graphics, "à", f2, new Point(50, 10), Color.Black);
            }
        }
    }
    }
