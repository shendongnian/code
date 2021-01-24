    private void button1_Click(object sender, EventArgs e)
            {
                Process[] processes = Process.GetProcessesByName("notepad");
                if (processes.Length > 0)
                {
                    SetWindowText(processes[0].MainWindowHandle, "This is My Notepad");
                    // Renaming title of 1st notepad instance
                    //processes[0]
                }
                else
                {
                    MessageBox.Show("Please start atleast one notepad instance..");
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Process[] processes = Process.GetProcessesByName("wordpad");
                if (processes.Length > 0)
                {
                    SetWindowText(processes[0].MainWindowHandle, "This is My wordpad");
                    // Renaming title of 1st notepad instance
                    //processes[0]
                }
                else
                {
                    MessageBox.Show("Please start atleast one wordpad instance..");
                }
            }
