    private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
    public void YourMethod()
    {
       DataTable table = null;
       try
       {
           using (SqlConnection connection = new SqlConnection(this.connectionString))
           {
               connection.Open();
               SqlCommand cmd = connection.CreateCommand();
           
               cmd.CommandText = "SP_active_user_profiles";
               cmd.CommandType = CommandType.StoredProcedure;
              
               using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
               {
                   table = new DataTable();
                   adapter.Fill(table);
               }
           }
           
       }
       catch (Exception ex)
       {
           //Handle your exeption
       }
    }
