    private void cmdRemote_Click(object sender, EventArgs e)
    {
        var process = new System.Diagnostics.Process();
        process.StartInfo = new ProcessStartInfo
		{
            FileName = "mstsc"
            Arguments = "/v:" + txtIP.Text
        }
        process.Start();
    }
