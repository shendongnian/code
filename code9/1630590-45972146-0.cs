    private void SaveBtn_Click(object sender, EventArgs e)
    {
        String filename = NameBox.Text;
        if (filename == "")
        {
            filename = "New Save";
        }
        filename += ".txt";
        System.IO.File.WriteAllText(filename, MainForm.Money.ToString());
        Application.Exit();
    }
