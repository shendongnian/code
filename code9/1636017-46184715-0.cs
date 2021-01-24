        public static List<string> GetCaseList(string[] masterIdList)
        {
            List<string> list = new List<string>();
            try
            {
                string query = "select CaseList from MasterReportData where ";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    int i = 0;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    for(i = 0; i < masterIdList.Length; i++)
                    {
                        var parm = "@ID" + i;
                        cmd.Parameters.Add(new SqlParameter(parm, masterIdList[i]));
                        query += (i > 0 ? " OR " : "") + " Id = " + parm;
                    }
                    cmd.CommandText = query;
                    //cmd.Parameters.AddWithValue("masterId", ***);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }
