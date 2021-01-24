        /// change here 
               cmd.CommandText = "INSERT INTO Receiver(Cname) " +
                    "values('" + Cname + "') ;select SCOPE_IDENTITY()"; 
             var newID= Convert.ToInt32( cmd.ExecuteScalar());
         --- better solution suggested by Steve is below -- I didnt tested this but this is approach .
     using (var cmd = new SqlCommand(@"INSERT INTO Receiver(Cname) VALUES (@cname)", conn))
        {
            cmd.Parameters.AddRange(
                new[]
                    {
                        new SqlParameter(@"cname", SqlDbType.VarChar).Value = cname
                    });
            conn.Open();
            cmd.ExecuteNonQuery();
        }
     
