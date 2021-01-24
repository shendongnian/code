            string stream = "";
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT X, Y, Z FROM SomeAmazingTable", conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var newContent = string.Format(
                    "{0}\t{1}"
                    , reader.GetValue(0).ToString().Trim()
                    , reader.GetValue(1).ToString().Trim()
                    );
                    stream = newContent + Environment.NewLine;
                }
                File.WriteAllText(pathAndFileName, stream);
                reader.Close();
            }
