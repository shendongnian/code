    private void UserControl1_Paint(object sender, PaintEventArgs e) {
        using (Font f = new Font("Wingdings", 12)) {
            TextRenderer.DrawText(e.Graphics, "à", f, new Point(10, 10), Color.Black);
            TextRenderer.DrawText(e.Graphics, "à", f, new Point(30, 10), Color.Black);
            TextRenderer.DrawText(e.Graphics, "à", f, new Point(50, 10), Color.Black);
        }
    }
