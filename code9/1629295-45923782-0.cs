    private bool updatingTheText;
    private void txt_Log_TextChanged(object sender, EventArgs e)
    {
        if (updatingTheText)
            return;
        const int max_lines = 200;
        if (txt_Log.Lines.Length > max_lines)
        {
            string[] newLines = new string[max_lines];
            Array.Copy(txt_Log.Lines, 1, newLines, 0, max_lines);
            updatingTheText = true;  // Disable TextChanged event handler
            txt_Log.Lines = newLines;
            updatingTheText = false; // Enable TextChanged event handler
        }
        txt_Log.SelectionStart = txt_Log.Text.Length;
        txt_Log.ScrollToCaret();
    }
