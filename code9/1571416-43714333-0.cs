    string fancyDebugString = "";
    foreach(Process p in Process.GetProcesses())
    {
        fancyDebugString += p.ProcessName + ",";
        //listBox1.Items.Add(p.ProcessName);
    }
    MessageBox.Show(fancyDebugString);  // or whatever feedback mechanism you can hook into.
