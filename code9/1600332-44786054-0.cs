    private void Form_OnClosing(object sender, EventArgs args)
    {
        Application.OpenForms[0].Close();
        Application.Exit();
        Environment.Exit();
    }
