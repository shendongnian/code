    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
            this.Font = new Font("Wingdings", 12);
        }
        private void UserControl1_Paint(object sender, PaintEventArgs e) {
            TextRenderer.DrawText(e.Graphics, "à", this.Font, new Point(10, 10), Color.Black);
            TextRenderer.DrawText(e.Graphics, "à", this.Font, new Point(30, 10), Color.Black);
            TextRenderer.DrawText(e.Graphics, "à", this.Font, new Point(50, 10), Color.Black);
        }
    }
