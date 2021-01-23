            ProcessStartInfo procstart = new ProcessStartInfo
            {
                FileName = "query",
                Arguments = "$"user /server:{computername}"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            Process proc = new Process {StartInfo = procstart};
            proc.Start();
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            Console.WriteLine(proc.StandardError.ReadToEnd());
            Console.Read();
