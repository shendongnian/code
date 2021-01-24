    using System.Reflection;
    static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
    {
        typeof(Control).InvokeMember("DoubleBuffered", 
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, 
            null, ctl, new object[] { DoubleBuffered });
    }
