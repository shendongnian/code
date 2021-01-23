    if (box.Text.Length > 0)
    {
        uiControls.ListItem melding = await Task.Factory.StartNew(() => sendMelding(name, box.Text));
        box.Clear();
    }
