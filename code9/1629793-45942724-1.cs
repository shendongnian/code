    private void LoadAccounts()
    {
        if (!File.Exists(path))
        {
            MessageBox.Show("File Doesn't Exist");
        }
            try
            {
                using (StreamReader reader = new StreamReader(path))
                    while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] accountinfo = line.Split(',');
                    accounts.Add(new WaterAccount(accountinfo[0], accountinfo[1], accountinfo[2],accountinfo[3],string.Empty, string.Empty));
                }
            }
            catch (IOException ex)
            {
                DialogResult result = MessageBox.Show("An error occurred, do you want to continue? - " + ex.Message, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    //Do more stuff or continue processing. . .
                }
                else if (result == DialogResult.No)
                {
                    //End application or stop processing...
                    //eg. you can stop the application.
                    Application.Exit();
                }
            }
    }
