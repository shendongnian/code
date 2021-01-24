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
        private string SqlToFile(string connString, string sql)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();
                    var values = new object[reader.FieldCount];
                    var sw = new StringWriter();
                    // column names
                    var columns = reader.GetColumnSchema();
                    sw.WriteLine(string.Join(",", reader.GetColumnSchema().Select(x => Escape(x.ColumnName))));
                    // values
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        sw.WriteLine(string.Join(",", values.Select(x => Escape(x.ToString()))));
                    }
                    reader.Close();
                    sw.Close();
                    return sw.ToString();
                }
            }
        }
