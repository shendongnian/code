    var buckets = new Dictionary<string, List<string>>();
    cmd.CommandText = "SELECT MobileNo FROM Customer";
    SqlDataReader dr = RunSqlReturnDR(cmd);
    if (dr.HasRows)
    {
        while (dr.Read())
        {
            var number = dr[0].ToString();
            var key = number.Substring(0, 3);
            List<string> numbers = null;
            if(!buckets.TryGetValue(key, out numbers))
            {
                numbers = new List<string>();                 
            }
            numbers.Add(number);
        }
    }
    dr.Close();
