    private List<string> readFromDatabase()
        {
            DataTable dt = PullData();
            List<string> tempList = new List<string>();
            if (dt != null & dt.Rows.Count >0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempList.Add(Convert.ToString(dt.Rows[i]["fieldName"]));
                    tempList.Add(Convert.ToString(dt.Rows[i]["dataType"]));
                    tempList.Add(Convert.ToString(dt.Rows[i]["numberOfCharacters"]));
                }
            }
            return tempList;
        }
        public DataTable PullData()
        {
            try
            {
                string connString = @"your connection string here";
                string query = "select * from table";
                DataTable dataTable = new DataTable();
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
