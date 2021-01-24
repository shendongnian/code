        private void LoadAccounts()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"{path} does not exist");
            }
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] accountinfo = line.Split(',');
                    accounts.Add(new WaterAccount(accountinfo[0], accountinfo[1], accountinfo[2], accountinfo[3], string.Empty, string.Empty));
                }
            }
        }
