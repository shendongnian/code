        public void ReadFile()
        {
            if (File.Exists(AccountsFile))
            {
                using (StreamReader Reader = new StreamReader(AccountsFile))
                using (StreamWriter Writer = new StreamWriter((AccountsFile)))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        string line;
                        if ((line = Reader.ReadLine()) == null)
                        {
                            Writer.WriteLine("Line Placeholder");
                        }
                        else
                            Writer.WriteLine(line);
                    }
                }
            }
            else
            {
                File.Create(AccountsFile);
            }
        }
