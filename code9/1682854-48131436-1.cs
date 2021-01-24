	private async void btnImportDataFromServer_Click(object sender, RoutedEventArgs e)
	{
		if (MessageBox.Show("Sure?", "Data sync", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            return;
		
		await ImportProducts();
		await LoadNewArticles(); // this will only start after ImportProducts() has finished succesfully		}
 	}
    private async Task ImportProducts()
	{
		List<Products> newProducts = new List<Products>();
		using (SqlConnection connection = GetSqlConnection())
		{
			connection.Open();
	
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "SELECT COUNT(*) FROM [dbo].[Products] T1 INNER JOIN [dbo].[ProductGroup] T2 ON T1.Code = T2.Code";
				command.Connection = connection;
	
			}
			using (SqlCommand command = new SqlCommand())
			{
				command.CommandText = "SELECT T1.[Code], [Title], [Description],[Price] FROM [dbo].[Products] T1 INNER JOIN [dbo].[ProductGroup] T2 ON T1.Code = T2.Code";
				command.Connection = connection;
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						// Omitted for brevity
					}
				}
			}
		}
	}
