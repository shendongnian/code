    static class MoveController
    {
        static List<Control> Controls { get; set; }
        static Control curCtl = null;
        static Point curStart = Point.Empty;
        static public void RegisterCtl(Control ctl)
        {
            if (Controls == null) Controls = new List<Control>();
            Controls.Add(ctl);
            ctl.MouseDown += ctl_MouseDown;
            ctl.MouseMove += ctl_MouseMove;
            ctl.MouseUp += ctl_MouseUp;
        }
        static public void UnRegisterCtl(Control ctl)
        {
            if (Controls != null && Controls.Contains(ctl) )
            {
                Controls.Remove(ctl);
                ctl.MouseDown -= ctl_MouseDown;
                ctl.MouseMove -= ctl_MouseMove;
                ctl.MouseUp -= ctl_MouseUp;
            }
        }
        static void ctl_MouseDown(object sender, MouseEventArgs e)
        {
            curCtl = (Control)sender;
            curStart = curCtl.Location;
        }
        static void ctl_MouseMove(object sender, MouseEventArgs e)
        {
            if (curCtl != null)
            {
                curCtl.Left +=  e.Location.X - curCtl.Width / 2;
                curCtl.Top  +=  e.Location.Y - curCtl.Height / 2;
            }
        }
        static void ctl_MouseUp(object sender, MouseEventArgs e)
        {
            curCtl = null;
        }
    }
 
