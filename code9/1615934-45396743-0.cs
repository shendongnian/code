    private async void connectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await Connect();
    }
    private async Task Connect()
    {
        if (!connected)
        {
            connected = true;
            verbindenToolStripMenuItem.Enabled = false;
            trennenToolStripMenuItem.Enabled = true;
            InfoStripStatus.Text = "Status: Connected";
            await Task.Run(() => irc.joinRoom(channel, BotConnectingMessage));
            chatThread = new Thread(getMessage);
            chatThread.Start();
            loadLoyalty();
            updateTimer = new System.Threading.Timer(timerViewer, null, 0, 60000);
        }
    }
