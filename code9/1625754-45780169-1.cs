    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_toBeIgnored)
        {
            e.Handled = true;
            return;
        }
    }
    private bool _toBeIgnored;
    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (IsKeyLocked(Keys.NumLock))
        {
            _toBeIgnored = true;
            return;
        }
    }
