    using (var proc = new System.Diagnostics.Process())
    {
        proc.StartInfo.Arguments = Path.Combine(c, d);
        proc.StartInfo.FileName = "notepad.exe";
        proc.Start();
    }
