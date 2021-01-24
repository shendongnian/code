            internal static void UpdateStatusForRuleID(SQLConnectionManager DBMANAGER, int ruleID, bool status)
        {
            string dbVal = (status) ? "1" : "0";
            MicroRuleEngine.Rule r = null;
            string newJSON = null;
            using (SQLiteConnection conn = DBMANAGER.CreateConnection())
            {
                string sql = String.Format("select * from rules WHERE ID = {0} ", ruleID.ToString());
                using (var command = new SQLiteCommand(sql, conn))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string json = reader["fulljson"].ToString();
                        r = Newtonsoft.Json.JsonConvert.DeserializeObject<MicroRuleEngine.Rule>(json);
                        r.Active = (status);
                        newJSON = Newtonsoft.Json.JsonConvert.SerializeObject(r);
                        string sql2 = "UPDATE rules SET active = @a, fulljson=@j WHERE ID = @i";
                        using (var command2 = new SQLiteCommand(sql2, conn))
                        {
                            command2.Parameters.Add(new SQLiteParameter("@a", dbVal));
                            command2.Parameters.Add(new SQLiteParameter("@i", ruleID));
                            command2.Parameters.Add(new SQLiteParameter("@j", newJSON));
                            command2.ExecuteNonQuery(); 
                        }
                    }
                }
            }
        }
