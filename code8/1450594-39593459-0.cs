    public static void UpdateData(DayBooks objEmployee, string eid) //Update data in database      
    {
        using (var con = new SqlConnection(strConnection))
        {
            var query = "UPDATE DayBooks set DayDesc=12345,VoucherNo=54321,VoucherNo1=1 where DayCode=12";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    } 
