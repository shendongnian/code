    class MoveController
    {
        static List<Control> Controls = new List<Control>();
        static Control curCtl = null;
        static Point curStart = Point.Empty;
        static Dictionary<Control, Tuple<Action, Action>> 
            actions = new Dictionary<Control, Tuple<Action, Action>>();
        static public void RegisterCtl(Control ctl)
        {
            RegisterCtl(ctl, null, null);
        }
        static public void RegisterCtl(Control ctl, Action moveAction, Action movedAction)
        {
            Controls.Add(ctl);
            ctl.MouseEnter += Ctl_MouseEnter;
            ctl.MouseLeave += Ctl_MouseLeave;
            ctl.MouseDown += ctl_MouseDown;
            ctl.MouseMove += ctl_MouseMove;
            ctl.MouseUp += ctl_MouseUp;
            if (moveAction != null)
                if (actions.Keys.Contains(ctl)) actions[ctl] = new Tuple<Action, Action>(moveAction, movedAction);
                else actions.Add(ctl, new Tuple<Action, Action>(moveAction, movedAction));
        }
        private static void Ctl_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Hand;
        }
        private static void Ctl_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
        }
        public static void UnRegisterCtl(Control ctl)
        {
            if (Controls != null && Controls.Contains(ctl) )
            {
                Controls.Remove(ctl);
                ctl.MouseDown -= ctl_MouseDown;
                ctl.MouseMove -= ctl_MouseMove;
                ctl.MouseUp -= ctl_MouseUp;
            }
            if (actions.ContainsKey(ctl)) actions.Remove(ctl);
        }
        static public void RegisterMovingAction(Control ctl, Action action)
        {
        }
        static void ctl_MouseDown(object sender, MouseEventArgs e)
        {
            curCtl = (Control)sender;
            curStart = curCtl.Location;
        }
        static void ctl_MouseMove(object sender, MouseEventArgs e)
        {
            int t = 0;
            if (curCtl != null)
            {
                if (curCtl.Tag != null) t = Convert.ToInt32(curCtl.Tag);
                if ((t&1) != 1) curCtl.Left +=  e.Location.X - curCtl.Width / 2;
                if ((t&2) != 2) curCtl.Top  +=  e.Location.Y - curCtl.Height / 2;
                if (actions.ContainsKey(curCtl) && actions[curCtl] != null && actions[curCtl].Item1 != null)
                    actions[curCtl].Item1();
            }
        }
        static void ctl_MouseUp(object sender, MouseEventArgs e)
        {
            if (curCtl == null) return;  ///
            if (actions.ContainsKey(curCtl) && actions[curCtl] != null && actions[curCtl].Item2 != null)
                actions[curCtl].Item2();
            curCtl = null;
        }
    }
 
