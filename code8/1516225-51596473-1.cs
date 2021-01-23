    class Program
    {
        [STAThread]
        static void Main()
        {
            RunTask().ContinueWith(t => { Application.Exit(); }); // run task asynchronously, then exit
            Application.Run(); // start processing messages
        }
    
        static async Task RunTask(OneDriveClient oneDriveClient = null)
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
        }
    }
