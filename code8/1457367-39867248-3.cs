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
        //form.MouseDown += form_MouseDown;
        form.Show();
    }
    void form_Paint(object sender, PaintEventArgs e)
    {
        using (Image img = Image.FromFile("D:\\proj.png"))
        e.Graphics.DrawImage(img, Point.Empty);
    }
    //void form_MouseDown(object sender, MouseEventArgs e)
    //{
    //    if (e.Button == MouseButtons.Left)
    //    {
    //        ReleaseCapture();
    //        SendMessage( ((Form)sender).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
    //    }
    //}
    //public const int WM_NCLBUTTONDOWN = 0xA1;
    //public const int HT_CAPTION = 0x2;
    //[DllImportAttribute("user32.dll")]
    //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    //[DllImportAttribute("user32.dll")]
    //public static extern bool ReleaseCapture();
