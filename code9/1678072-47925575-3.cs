    internal void DoAsyns2( SqlCommand sqlCommand )
    {
      SqlDataReader reader = sqlCommand.ExecuteReader();
      Product prd;
      List productList = new List<Product>();
      while (reader.Read())
      {
        prd = new Product()
        {
            Name = reader["Name"].ToString(),
            Amout = Convert.ToDecimal(reader["Amout"]),
            Price = Convert.ToDecimal(reader["Price"])
        };
          productList.add(prd);
        }
      }
      Dispatcher.Invoke(() =>
      {
        Products = new ObservableCollection<Product>(productList);
      };
    }
