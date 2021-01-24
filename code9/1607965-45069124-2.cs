    private void browsebutton_Click(object sender, EventArgs e)
    {
        var serversFile = @"f:\public\temp\servers.txt";
        var servers = File.ReadAllLines(serversFile)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Replace(" ", ""));
        foreach (var server in servers)
        {
            var color = PingServer(server)
                ? Color.Green
                : Color.Red;
            AddColoredItemToListView(listView1, server, color);
        }
    }
