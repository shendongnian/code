    class Program
    {
        [STAThread]
        static void Main()
        {
            var appContext = new ApplicationContext();
            RunTask(appContext); // run task asynchronously, pass ApplicationContext
            Application.Run(); // start processing messages
        }
    
        static async Task RunTask(ApplicationContext appContext, OneDriveClient oneDriveClient = null)
        {
            try
            {
                Task authTask = null;
                if (oneDriveClient == null)
                {
                    var msaAuthenticationProvider = new MsaAuthenticationProvider("CLIENT_ID",null, "https://login.live.com/oauth20_desktop.srf", new[] { "onedrive.readonly", "wl.signin" }, null, new CredentialVault("CLIENT_ID));
                    authTask =  msaAuthenticationProvider.AuthenticateUserAsync();
                }
            
                await authTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                appContext.ExitThread(); // stop messaging loop
            }
        }
    }
