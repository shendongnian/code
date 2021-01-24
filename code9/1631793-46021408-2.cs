    if (Clipboard.ContainsText(TextDataFormat.Text)) {
        string[] clipboardText = Clipboard.GetText(TextDataFormat.Text).Split('|');
        foreach (string link in clipboardText) {
            if (Uri.TryCreate(link, UriKind.Absolute, out var uri)) {
                rtbLinks.AppendText(uri + "\n");
            }
        }
    }
