     static class Program
    {
		public static bool IsAdministrator()
		{
			var identity = WindowsIdentity.GetCurrent();
			var principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			if (IsAdministrator())
			{
				UserRights.RunAsDesktopUser(@"C:\Program Files (x86)\XMLMailService\XMLMailWF.exe");
				Form1.benciktim = true;
				Application.Exit();
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
            
        }
    }
