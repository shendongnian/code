    private async void Button1_Click(object sender, EventArgs e)
    {
      try
      {
        var osVersion = await Task.Run(() => CheckStatus());
        richTextBox1.AppendText("OS version is : " + osVersion);
        richTextBox1.AppendText(Environment.NewLine);
      }
      catch (InvalidOperationException ex)
      {
        richTextBox1.AppendText("Error getting registry value from" + ComputerName);
        richTextBox1.AppendText(ex.ToString());
        richTextBox1.AppendText(Environment.NewLine);
      }
    }
    private string CheckStatus()
    {
      ServiceController sc = new ServiceController("RemoteRegistry", ComputerName);
      if (sc.Status == ServiceControllerStatus.Stopped)
      {
        // Start the service if the current status is stopped.
        // Start the service, and wait until its status is "Running".
        sc.Start();
        sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 3));
        sc.Refresh();
        sc.WaitForStatus(ServiceControllerStatus.Running);
      }
      var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ComputerName);
      var key = reg.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\");
      return (key.GetValue("CurrentVersion")).ToString();
    }
