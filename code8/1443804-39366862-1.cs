    protected void Page_Load(object sender, EventArgs e)
        {
           
                SecureString sc = new SecureString();
                string Source = "*****";
                foreach (char c in Source.ToCharArray())
                {
                    sc.AppendChar(c);
                 
                }
                sc.MakeReadOnly();
                try
                {
                    ProcessStartInfo i = new ProcessStartInfo(@"C:\******\myapp.exe", "test");
                    i.Domain = "*****";
                    i.UserName = "*****";
                    i.UseShellExecute = false;
                    i.CreateNoWindow = true;
                    i.RedirectStandardOutput = true;
                    i.Password = sc;
                    i.Verb = "runas";
                    Process p = new Process();
                    p = Process.Start(i);
                }
                catch (Win32Exception w32E)
                {
                   // Display Some Message
                }
    }
