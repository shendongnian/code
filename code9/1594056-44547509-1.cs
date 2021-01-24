    public IEnumerable<SalesModel> getSale(DateTime StartDate, DateTime EndDate)
    {
        string sql = "select * from Sale where date is not null and (date between @StartDate and @EndDate) order by date";
    
        using (var cn = new SqlConnection(DB.ConnectionString))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate
            cn.Open();
    
            using (var rdr = cmd.ExecuteReader())
            {
                while(db.dataReader.Read())
                {
                    SaleModel sm = new SaleModel();
                    sm.SaleId = (long)rdr["Id"];
                    sm.UserName = rdr["UserName"].ToString();
                    sm.ItemsQuantity = (int)rdr["ItemsQuantity"];
                    sm.TotalAmount = (double)rdr["TotalAmount"]);
                    sm.SubTotal = (double)rdr["SubTotal"];
                    sm.Discount = (double)rdr["Discount"];
                    sm.Completed = (bool)rdr["Completed"];
                    sm.Date = (DateTime)rdr["Date"];
                    sm.CustomerPhone = (long).rdr["CustomerPhone"];
    
                    yield return sm;
                }
            }
        }
    }
