    //accept the date values as parameter arguments, return the result. 
    //  Do NOT mess about with variables at the global or class scope.
    public IEnumerable<SalesModel> getSale(DateTime StartDate, DateTime EndDate)
    {
        string sql = "select * from Sale where date is not null and (date between @StartDate and @EndDate) order by date";
 
        //DON'T abstract SqlCommand/SqlConnection. DO abstract your connection string.
        //Also, don't bother with the try/catch at this level. You can't really do anything with it here, so worry about the exception in calling code.
        using (var cn = new SqlConnection(DB.ConnectionString))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate
            cn.Open();
              
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    var sm = new SaleModel();
                    //If you have good schema design, these values are **already** in the correct type. 
                    // The old code forces an expensive conversion to string, following by an expensive parse back to the type it already had.
                    // We can do MUCH better.
                    sm.SaleId = (long)rdr["Id"];
                    //but it is okay for types that are *already* strings
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
