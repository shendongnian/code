    private async void GetInfoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in infoDataGridView.Rows)
            await this.GetInfoAsync(row);
    }
    
    private async Task GetInfoAsync(DataGridViewRow row)
    {
        Server server = (Server)row.Cells[0].Value;
        row.Cells[1].Value = Resources.GettingIcon;
    
        await Task.Run(() =>
        {
            server.Data = dataGetter.GetData(server);
        });
    
        row.Cells[1].Value = Resources.FinishedIcon;
    }
