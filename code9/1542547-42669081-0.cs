    private void frmTest_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Location.X >= panel1.Bounds.X && e.Location.X <= (panel1.Bounds.X + panel1.Bounds.Width) && e.Location.Y >= panel1.Bounds.Y && e.Location.Y <= (panel1.Bounds.Y + panel1.Bounds.Width))
      {
        panel1.Visible = false;
      }
      else
      {
        panel1.Visible = true;
      }
    }
    
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      panel1.Visible = false;
    }
