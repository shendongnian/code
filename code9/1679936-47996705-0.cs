    public static class ControlHelper
    {
        public static T GetCtrl<T>(this Control c, string name) where T : Control
        {
            return c.FindControl(name) as T;
        }
    }
