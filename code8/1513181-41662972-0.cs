      public void AddItem(Item item)
				{
				 var cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
					var cmd = "INSERT INTO Items([Name],Description] ,[Price] , [Currency] ,  [Negotiable], [CategoryId], [OwnerId] ) VALUES(@id,@name,@description,@price,@currency,@negotiable,@categoryId,@ownerId)";
					using (SqlConnection cnn = new SqlConnection(cnnString))
					{
						using (SqlCommand cmd1 = new SqlCommand(cmd, cnn))
						{
							cmd1.Parameters.AddWithValue("@id", item.Id);
							cmd1.Parameters.AddWithValue("@name", item.Name);
							cmd1.Parameters.AddWithValue("@description", item.Description);
							cmd1.Parameters.Add("@price", SqlDbType.Decimal).Value = item.Price;
							cmd1.Parameters.AddWithValue("@currency", item.Currency);
							cmd1.Parameters.AddWithValue("@negotiable", item.Negotiable);
							cmd1.Parameters.AddWithValue("@categoryId", item.CategoryId);
							cmd1.Parameters.AddWithValue("@ownerId", item.OwnerId);
							cnn.Open();
							cmd1.ExecuteNonQuery();  //*
						}
					}
				}
