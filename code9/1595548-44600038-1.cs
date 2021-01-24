    namespace MyProject.Models
    {
        public class SelectModel
        {
            private static SqlConnection GetCn()
            {
                 SqlConnection cn = new SqlConnection(@"MyConnectionString");
                 return cn;
            }
            public string SearchText { get; set; }
            public DataSet GetAccounts()
            {
                SqlConnection cn = GetCn();
                SqlCommand cmd;
                if (!string.IsNullOrEmpty(this.SearchText))
                {
                     var sqlQuery = "SELECT * FROM tblaccount WHERE accountNo = @accountNo ORDER BY accountNo ASC";
                     cmd = new SqlCommand(sqlQuery, cn);
                     cmd.Parameters.Add(new SqlParameter("accountNo", SqlDbType.NVarChar);
                     cmd.Parameters[0].Value = this.SearchText;
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM tblaccount ORDER BY accountNo ASC", cn);
                }
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
    }
