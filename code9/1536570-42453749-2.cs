    public static List<string> GetTokensForUsers(List<string> userIds)
    {
       //Prepare table structure to be passed to the command as parameter.
       DataTable tvp = new DataTable();
       var dc = new DataColumn("strValue", typeof(string));
       tvp.Columns.Add(dc);
       //Add values to the table which will be used in the stored proc.
       foreach (var userId in userIds)
       {
           var dr = tvp.NewRow();
           dr["strValue"] = userId;
           tvp.Rows.Add(dr);
       }
       var tokens = new List<string>();
       using (var conn = new SqlConnection("Data Source=MyServer;Initial Catalog=MyDb;user id=username;password=pwd"))
       {
           SqlCommand cmd = new SqlCommand("dbo.SelectToken", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           //Pass table as parametr to the command.
           SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
           //Setting Type of the parameter.
           tvparam.SqlDbType = SqlDbType.Structured;
           conn.Open();
    
           var reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               tokens.Add(reader.GetString(1));
           }
    
       }
       return tokens;
    }
