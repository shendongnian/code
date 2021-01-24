    public class LoginHistory {
        public int LoginHistoryId { get; set; }
        public string UserName { get; set; }
        public int Hit_Count { get; set; }
        public DateTime LoginDate { get; set; }
        public List<LoginHistory> GetLoginTotals() {
            List<LoginHistory> retValue = new List<LoginHistory>();
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine("SELECT username, COUNT(*) ");
            sbQuery.AppendLine("FROM LoginHistory ");
            sbQuery.AppendLine("GROUP BY username");
            using (SqlConnection conn = new SqlConnection(strConn)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sbQuery.ToString(), conn)) {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var row = new LoginHistory {
                                UserName = reader.GetString(0)
                                , Hit_Count = reader.GetInt32(1)
                            };
                            retValue.Add(row);
                        }
                    }
                }
                conn.Close();
            }
            return retValue;
        }
    }
