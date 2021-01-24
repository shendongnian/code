    public static class MyExtensions
    {
       public static void InvokeBy(this Control ctl, MethodInvoker method)
       {
           if (ctl.InvokeRequired)
               ctl.Invoke(method);
           else method();
       }
    }
