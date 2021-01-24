    proc = Process.GetProcesses()
        .OrderBy(p => p.ProcessName)
        .ToArray();
    proc.Select(p => p.ProcessName)
        .Select(listBox1.Items.Add);
