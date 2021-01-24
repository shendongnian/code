    private async void Button1_Click(object sender, EventArgs e)
    {
      try
      {
        var progress = new Progress<string>(update =>
        {
          TxtBoxstatus.AppendText(update);
          TxtBoxstatus.AppendText(Environment.NewLine);
        });
        var osVersion = await Task.Run(() => CheckStatus(progress));
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
    private string CheckStatus(IProgres<string> progress)
    {
      progress?.Report("Checking Remote Registry service status on computer : " + ComputerName);
      progress?.Report("Please wait... ");
      ServiceController sc = new ServiceController("RemoteRegistry", ComputerName);
      progress?.Report("The Remote Registry service status is currently set to : " + sc.Status.ToString());
      if (sc.Status == ServiceControllerStatus.Stopped)
      {
        // Start the service if the current status is stopped.
        progress?.Report("Starting Remote Registry service...");
        // Start the service, and wait until its status is "Running".
        sc.Start();
        sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 3));
        sc.Refresh();
        sc.WaitForStatus(ServiceControllerStatus.Running);
        progress?.Report("The Remote Registry status is now set to:" + sc.Status.ToString());
      }
      var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ComputerName);
      var key = reg.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\");
      return (key.GetValue("CurrentVersion")).ToString();
    }
