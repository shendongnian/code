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
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblaccount WHERE accountNo = '"+txtSearchterm+"'ORDER BY accountNo ASC"", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
    }
