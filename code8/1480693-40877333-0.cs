    public string CipheredString(string userMessage)
        {
            string[] columnEncrypted = userMessage.Split(' ');
            string[] columnDecrypted = new string[6];
            string DecryptedString = string.Empty;
            string DirtyDecrypt = string.Empty;
            columnDecrypted[0] = columnEncrypted[5];
            columnDecrypted[1] = columnEncrypted[2];
            columnDecrypted[2] = columnEncrypted[4];
            columnDecrypted[3] = columnEncrypted[3];
            columnDecrypted[4] = columnEncrypted[0];
            columnDecrypted[5] = columnEncrypted[1];
            for (int c = 0; c < columnDecrypted[0].Length; c++)
            {
                for (int r = 0; r < 6; r++)
                {
                    string row = columnDecrypted[r];
                    string column = row[c].ToString();
                    DirtyDecrypt += column;
                }
            }
            string CleanDecrypt = DirtyDecrypt.Replace("_", " ").Replace("*","");
            return CleanDecrypt;
        }
