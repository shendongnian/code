            public static Dictionary<string, DateTime> LonView()
            {
                string sql = "SELECT Marks,Id FROM table4";
                Dictionary<string, DateTime> lst = null;
                using (SqlConnection Connection = new SqlConnection((@"DataSource")))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Connection.Close();
                        lst = dt.AsEnumerable()
                            .GroupBy(x => x.Field<string>("Marks"), y => y.Field<DateTime>("Id"))
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    }
                }
                return lst;
            }
