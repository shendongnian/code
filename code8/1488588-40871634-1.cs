    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        // Disable the form
        Enabled = false; 
        // Some action where the user moved the mouse cursor to a different location
        MessageBox.Show(this, "Message");
        // Re-enable the form
        Enabled= true;
        // Hack to clear the button highlight
        toolStrip1.ClearAllSelections();
    }
