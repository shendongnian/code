    private void button35_Click_1(object sender, EventArgs e)
    {
        Form form = new Form();
        //form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //form.MaximizeBox = false;
        //form.MinimizeBox = false;
        //form.ControlBox = false;
        form.BackColor = Color.Fuchsia;
        form.TransparencyKey = form.BackColor;
        form.BackgroundImage = Image.FromFile("D:\\pie.png");
        form.Paint += form_Paint;
        form.Show();
    }
    void form_Paint(object sender, PaintEventArgs e)
    {
        using (Image img = Image.FromFile("D:\\proj.png"))
        e.Graphics.DrawImage(img, Point.Empty);
    }
