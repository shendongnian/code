    ProcessStartInfo myProcess = new ProcessStartInfo(path);
    myProcess.UserName = username;
    myProcess.Password = MakeSecureString(password);
    myProcess.WorkingDirectory = @"C:\Windows\System32";
    myProcess.UseShellExecute = false;
    Process.Start(myProcess);
    private static SecureString MakeSecureString(string text)
    {
         SecureString secure = new SecureString();
         foreach (char c in text)
         {
             secure.AppendChar(c);
         }
         return secure;
    }
