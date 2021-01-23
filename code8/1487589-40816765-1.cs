    string query = @"select top 1 OrderNumber 
                    from tblOrderMaster 
                    where OrderedDate BETWEEN @startDate AND @endDate";
    using(SqlConnection conn = new SqlConnection("connectionString here"))
    {
        using(SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@startDate", txtfromcal.Text);
            cmd.Parameters.AddWithValue("@endDate", txttocal.Text);
            try
            {
                conn.Open();
                // other codes
                // to fetch the record
            }
            catch(SqlException e)
            {
                // do something with 
                // e.ToString()
            }
        }
    }
