    public List<SaleModel> GetSale(DateTime startDate, DateTime endDate)
    {
        string sql = @"select * from Sale 
                       where date is not null 
                       and date between @StartDate and @EndDate 
                       order by date";
        var salesList = new List<SaleModel>();
        try
        {
            using (var con = new SqlConnection("insert your connection string"))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SaleModel sm = new SaleModel();
                        sm.SaleId = long.Parse(reader["Id"].ToString());
                        sm.UserName = reader["UserName"].ToString();
                        sm.ItemsQuantity = int.Parse(reader["ItemsQuantity"].ToString());
                        sm.TotalAmount = double.Parse(reader["TotalAmount"].ToString());
                        sm.SubTotal = double.Parse(reader["SubTotal"].ToString());
                        sm.Discount = double.Parse(reader["Discount"].ToString());
                        sm.Completed = bool.Parse(reader["Completed"].ToString());
                        sm.Date = DateTime.Parse(reader["Date"].ToString());
                        sm.CustomerPhone = long.Parse(reader["CustomerPhone"].ToString());
                        salesList.Add(sm);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }
        return salesList;
    }
