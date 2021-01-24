    public void InsertData()
    {
       string connectionString = "Connection String B";
       string insertStatment = "INSERT INTO SOMETABLE (Email, Badge, Name) VALUES (@Email, @Badge, @Name)";
       List<Foo> dataList = GetData();
       if(dataList.Count > 0)
       {
         using (var con = new SqlConnection(connectionString))
         {
           using (var cmd = new SqlCommand(insertStatment, con))
           {
             con.Open();
             foreach (var items in dataList)
             {
               cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = items.Email;
               cmd.Parameters.Add("@Badge", SqlDbType.NVarChar).Value = items.Badge;
               cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = items.Name;
              }
               cmd.ExecuteNonQuery();
            }
          }
        }
     }
