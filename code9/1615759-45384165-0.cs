    public static void Sample(){
        try
        {
            Console.Write("Password: ");
            StringBuilder password = new StringBuilder();
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                password.Append(key.KeyChar);
            }
    
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WorkingDirectory = "C:/path_to/Gulp",
                Arguments = $"/c \"gulp browserSync\"",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UserName = Machine.User(),
                PasswordInClearText = password.ToString(),
                Domain = Machine.Domain(),
                CreateNoWindow = false
            };
    
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            proc.WaitForExit();
        } catch (Exception ex)
        {
            System.Console.WriteLine(ex);
            System.Console.ReadKey();
        }
    }
