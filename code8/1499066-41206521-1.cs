    // Main form
    private void button2_Click(object sender, EventArgs e)
    {
        var dlg = new ModalBox();
        if (dlg.ShowDialog(this)==DialogResult.OK)
        {
            // do things
        }
    }
