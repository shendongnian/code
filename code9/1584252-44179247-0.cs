    public IList<Danie> GetDish()
            {
                var result = new List<Dish>();
                using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["RestaurantCN"].ConnectionString))
                {
                    var sqlCommand = new SqlCommand("SELECT * FROM Dish", sqlCon);
                    sqlCon.Open();
    
                    var dr = sqlCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        var newDish = new Dish
                        {
                            IdDish = (int)dr["IdDish"],
                            Name = dr["Name"].ToString(),
                            Price = (int)dr["Price"]
                            ImagePath= (string)dr["Image"]
                        };
                        result.Add(newDish);
                    }
                    dr.Dispose();
                }
                return result;
            }
