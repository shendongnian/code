    public static class Extensions
    {
        public static void InvokeAction(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(() => { action(); }));
            }
            else
            {
                action();
            }
        }
    }
