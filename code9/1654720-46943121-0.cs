    private void BeginScanButton_Click(object sender, EventArgs e)
    {
        BeginScanButton.Enabled = false;
        if (_osuDirectory == null)
            MessageBox.Show("You have not chosen an Osu! directory yet.");
            BeginScanButton.Enabled = false;
        else
        {
            ScanFilesInParallel();
        }
