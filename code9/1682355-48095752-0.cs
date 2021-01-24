    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    private DataSet GetSuggestions(string searchTerm)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
        {
           SqlCommand com = new SqlCommand("SELECT TOP 2 YourColumn FROM YourTable WHERE YourField LIKE '@term%' ORDER BY SomeColumn", con);
           com.Parameters.AddWithValue("term", searchTerm);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            con.Close();
            return ds;
        }
     }
