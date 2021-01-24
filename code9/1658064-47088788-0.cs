      public partial class Class1
        {
    
            private static WebClient wc = new WebClient();
            private static ManualResetEvent handle = new ManualResetEvent(true);
            private static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            private static Thread thread;
            private BackgroundWorker worker = null;
    
    
            void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                // "SQL Server Download Completed...";
                //install SQL Server
                string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Process.Start(pathUser, @"/q /Action=Install /IACCEPTSQLSERVERLICENSETERMS /Hideconsole /Features=SQLEngine /InstanceName=SQLSERVER2012  /SECURITYMODE= “SQL” /UPDATEENABLED=false /SQLSYSADMINACCOUNTS=""NT AUTHORITY\SYSTEM"" /SQLSVCACCOUNT=""NT AUTHORITY\SYSTEM"" /BROWSERSVCSTARTUPTYPE=""Automatic""");
    
            }
    
            private void DownloadSQL()
            {
                string output = string.Empty;
                pathUser = pathUser.Replace("\\", "/");
                string filePath = "http://www.almsysinc.com/soft/files/microsoft/SQLEXPR_x86_ENU_2012.exe";
                var files = filePath.Split('/');
                pathUser = pathUser + @"/" + files[files.Count() - 1];
                thread = new Thread(() =>
                {
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    wc.DownloadFileAsync(new Uri(filePath), pathUser);
                    handle.WaitOne(); // wait for the async event to complete
                });
                thread.Start();
            }
