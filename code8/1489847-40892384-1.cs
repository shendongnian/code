	@{
		using(SqlConnection Praktikum2 = new SqlConnection("Data Source=Mark\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True"))
		using(SqlCommand command = new SqlCommand("SELECT KategoryID FROM Kategory WHERE Name = @name", Praktikum2))
		{
			command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar){ Value = Request.Params["kategory"]});
			connection.Open();
			using(SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					string ID = reader["KategorieID"].ToString() ;
					Console.WriteLine("ID = {0}", ID);
				}
			}
		}
	}
