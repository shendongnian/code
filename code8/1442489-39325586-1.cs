    if (System.Windows.Forms.SystemInformation.MonitorCount != 1)
    {
                Form form2 = new Form();
                form2.Left = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width + 1;
                form2.Top = 0;
                form2.ShowDialog();
     }
