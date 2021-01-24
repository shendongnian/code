      Process p1 = new Process();
            p1.StartInfo.FileName = "cmd";
            p1.StartInfo.Arguments = "/c java";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardError = true;
            p1.StartInfo.Verb = "runas";
            p1.Start();
         
            StringBuilder sb = new StringBuilder();
            while (!(p1.StandardOutput.EndOfStream))
                 sb.Append($"{ p1.StandardOutput.ReadLine()}");
            
            while (!(p1.StandardError.EndOfStream))
                sb.Append($"{ p1.StandardError.ReadLine()}");
            p1.WaitForExit();
