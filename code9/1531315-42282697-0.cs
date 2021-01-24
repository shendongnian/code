    private async void MainForm_Load(object sender, EventArgs e)
    {
      var ServerConfigFile = new ClientConfigFile(Environment.CurrentDirectory);
      ServerConfigFile.GenerateConfigFile();
      await CheckUpdateAsync();
      lblUpdateMessage.Text = "Finished...";
    }
    private async Task CheckUpdateAsync()
    {
      var connection = new ServerConnection(this);
      lblFileDownload.Text = "Downloading";
      lblFileDownload.Text = "Done";
      await Task.Run(() => connection.GetServerConfig());
      // some unrelated control changes here
    }
