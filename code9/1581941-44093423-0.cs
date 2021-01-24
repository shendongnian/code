    Process[] processes = Process.GetProcesses();
    List<string> found = new List<string>();
    foreach (var process in processes)
    {
        if (listView1.Items.Cast<ListViewItem>().Any(i => i.Text.Contains(process.ProcessName))){
            found.Add(process.ProcessName);
        }
     }
    }
