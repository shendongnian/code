    protected override void OnMouseMove(MouseEventArgs e) {
      base.OnMouseMove(e);
      if (e.Button == MouseButtons.Left) {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }
    protected override void OnClick(EventArgs e) {
      base.OnClick(e);
      MessageBox.Show("Clicked");
    }
