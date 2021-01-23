    private void doWorkButton_Click(object sender, EventArgs e)
    {
        …
        for (i = 0; i < 2000000; i++)
        {
            Data = …
            ExecuteQuery(Data);
        }
    }
