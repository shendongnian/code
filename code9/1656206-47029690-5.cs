       int pid = System.Diagnostics.Process.GetCurrentProcess().Id;
       System.Text.StringBuilder sb = new System.Text.StringBuilder(4096);
       int ret = Mono.Unix.Native.Syscall.readlink($"/proc/{pid}/exe", sb);
       string res = sb.ToString();
       System.Console.WriteLine(res);
            
