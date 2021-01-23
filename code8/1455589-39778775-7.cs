            private static void Exec(SqlConnection c, string s)
            {
                using (var m = c.CreateCommand())
                {
                    m.CommandText = s;
                    m.ExecuteNonQuery();
                }
            }
