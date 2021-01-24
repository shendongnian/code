    int backSlashIndex = -1;
    private void batchRootFolderText_TextChanged(object sender, EventArgs e)
    {
        if (!batchRootFolderText.Text.EndsWith("\\"))
        {
            if(backSlashIndex != -1)
            {
                var text = batchRootFolderText.Text;
                batchRootFolderText.Text = text.Substring(0, backSlashIndex) + text.Substring(backSlashIndex + 1, text.Length);
            }
            batchRootFolderText.Text = batchRootFolderText.Text + "\\";
            backSlashIndex = batchRootFolderText.Text.Length;
        }
    }
