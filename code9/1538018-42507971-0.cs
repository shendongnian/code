    public static class ControlExtensions
    {
        public static void ForControls<T>(this Control ctrl, Func<T, bool> where, Action<T> action) where T : Control
        {
            if (ctrl is T)
                if (where(ctrl as T))
                    action(ctrl as T);
            foreach (Control childControl in ctrl.Controls)
            {
                childControl.ForControls(where, action);
            }
        }
    }
