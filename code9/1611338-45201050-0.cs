    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {     
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        // call your code here...
      }
    }
