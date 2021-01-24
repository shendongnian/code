    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
        _isTextSelected = richTextBox1.SelectedText != "";
        EnableContextMenu();
    }
    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        int positionToSearch = richTextBox1.GetCharIndexFromPosition(e.Location);
        _isInSelectedText = positionToSearch >= richTextBox1.SelectionStart && positionToSearch < richTextBox1.SelectionStart + richTextBox1.SelectionLength;
        EnableContextMenu();
    }
