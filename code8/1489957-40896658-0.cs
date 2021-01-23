    private bool ignoreClick = false;
    private void btn_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        ignoreClick = true;
        btn.Left = e.X + btn.Left - mouseDownLocation.X;
        btn.Top = e.Y + btn.Top - mouseDownLocation.Y;
      }
    }
    private void btn_MouseUp(object sender, MouseEventArgs e) {
      ignoreClick = false;
    }
    private void btn_Click(object sender, EventArgs e) {
      if (!ignoreClick) {
        // do your click code...
      }
    }
