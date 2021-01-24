    private void button1_Click(object sender, EventArgs e)
    {
        FileSystem.CopyDirectory(
            @"c:\src",
            @"c:\dst",
            UIOption.AllDialogs,
            UICancelOption.DoNothing);
    }
