     private void button_Click(object sender, EventArgs e)
    {
    var _synchronizationContext = WindowsFormsSynchronizationContext.Current;
                Process p = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo =
                    {
                        FileName = "NOTEPAD.EXE",
                        Arguments = _path,
                        WindowStyle = ProcessWindowStyle.Maximized,
                        CreateNoWindow = false
                    }
                };
    
                p.Exited += (a, b) =>
                {
                    _synchronizationContext.Post(_=> RefreshTextBox(), null);
                    p.Dispose();
                };
    
                p.Start();
        }
