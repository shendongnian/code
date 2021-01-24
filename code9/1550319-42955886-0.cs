    public static void SetControlDraggable(this Control control)
    {
      Point mouseDownLocation = Point.Empty;
      control.MouseDown += (s, e) =>
        {
          if (e.Button == MouseButtons.Left) mouseDownLocation = e.Location;
        }
      control.MouseUp += (s, e) =>
        {
          if (e.Button == MouseButtons.Left)
          {
            control.Left = e.X + control.Left - mouseDownLocation.X;
            control.Top = e.Y + control.Top - mouseDownLocation.Y;
          }
        }
    }
