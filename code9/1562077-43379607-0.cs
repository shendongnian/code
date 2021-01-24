    void GetAllProcess()
    {
        proc = Process.GetProcesses();
        listBox1.Items.Clear();
        foreach (Process p in proc.OrderBy(m=>m.ProcessName))
        {
            listBox1.Items.Add(p.ProcessName);
        }
    }
