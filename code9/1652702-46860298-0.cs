        string str = textBox1.Text.Trim();
            query = "SELECT * FROM LOG WHERE ENTRY like '%' || @str || '%'";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            // Might need a different data type here
            cmd.Parameters.Add("@str",  SQLiteType.Text).Value = str;
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add((string)reader["ENTRY"]);
                }
            }
        }
