        private const string QUOTE = "\"";
        private const string ESCAPED_QUOTE = "\"\"";
        private static char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n', '\r' };
        private static string Escape(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            if (s.Contains(QUOTE))
                s = s.Replace(QUOTE, ESCAPED_QUOTE);
            if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
                s = QUOTE + s + QUOTE;
            return s;
        }
        private void SqlToFile(string Sql, string FileName)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            string[] outline = new string[reader.FieldCount];
            StreamWriter sw = new StreamWriter(FileName);
            while (reader.Read())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        outline[i] = Escape(reader.GetValue(i).ToString());
                    sw.WriteLine(String.Join(",", outline));
                }
            }
            reader.Close();
            sw.Close();
        }
