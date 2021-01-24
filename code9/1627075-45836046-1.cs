    public List<Foo> GetData()
    {
       List<Foo> dataList = new List<Foo>();
       string connectionString = "Connection String A";
       string selectStatement = "SELECT Email, Badge, Name FROM PublishedWorks";
       using (var con = new SqlConnection(connectionString))
       {
         using (var cmd = new SqlCommand(selectStatement, con))
         {
           con.Open();
           using (var reader = cmd.ExecuteReader())
           {
              dataList.Add(new Foo
              {
                Email = reader.GetString(0),
                Badge = reader.GetString(1),
                Name = reader.GetString(2)
               });
             }
            }
          }
        return dataList;
    }
