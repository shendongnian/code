    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            bldr.IntegratedSecurity = true;
            bldr.InitialCatalog = "YourDB";
            bldr.DataSource = "(localdb)\\YourServer";
            bldr.Pooling = false;  //Comment and uncomment this and run sp_who2
            using (SqlConnection con = new SqlConnection(bldr.ConnectionString))
            {
                con.Open();
            }
        }
    }
