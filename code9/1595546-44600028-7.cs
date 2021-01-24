     namespace MyProject.Models
        {
        public class SelectModel
        {
            private static SqlConnection GetCn()
            {
                SqlConnection cn = new SqlConnection(@"MyConnectionString");
                return cn;
            }
        
             //updated
            public DataSet GetAccounts(string txtSearchterm)
            {
                SqlConnection cn = GetCn();
           string sqlquery = "";
                if(txtsearchterm != null)
          {
           sqlquery ="SELECT * FROM tblaccount WHERE accountNo = 
           '"+txtSearchterm+"'ORDER BY accountNo ASC""
           }
        else
       {
         sqlquery ="SELECT * FROM tblaccount ORDER BY accountNo ASC""
       }
                SqlCommand cmd = new SqlCommand(sqlquery , cn);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        }
