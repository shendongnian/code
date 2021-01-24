    public static class StdMethods
    {
       public static string GetExePath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;            
        }
    public static void SetFullScreenMode()
        {
          this.Top = 0;
          this.Left = 0;
          this.Width = SystemParameters.WorkArea.Width;
          this.Height = SystemParameters.WorkArea.Height;
        }
    }
