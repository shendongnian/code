        public abstract class BaseSupplier
        {
            public void Connect(FTPCredentials credentials, Process process, SupplierSettingClass settings)
            {
                 var ftp = new FtpConnection(credentials.Host, credentials.Username, credentials.Password);
                 ftp.Open();
                 ftp.Login();
                 DoSomething(settings);
                 ftp.Close();
            }
            public virtual void DoSomething(SupplierSettingClass settings)
            {
                 //define base case;
            }
        }
