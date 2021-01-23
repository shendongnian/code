    private void SetText(string text, Control control)
    {
        if (control.InvokeRequired)
            control.Invoke(new Action(() => control.Text = text));
        else
            control.Text = text;
    }
