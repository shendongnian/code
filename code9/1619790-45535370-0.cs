        [DllImport("User32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
 
        private void ListTask()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
                listBox1.Items.Add(process.ProcessName);
        }
 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process p = new Process();
            string name = listBox1.SelectedItem.ToString();
            p = Process.GetProcessesByName(name)[0];
            const uint SWP_SHOWWINDOW = 0x0001;
            ShowWindow(p.MainWindowHandle, SWP_SHOWWINDOW);
            SetForegroundWindow(p.MainWindowHandle);
            p.Dispose();
        }
