        var monthList = new Dictionary<String, List<String>>();
        foreach (DataRow dr in dsSeries.Tables[0].Rows)
        {
            var key = dr["MonthName"].ToString();
            var value = dr["Department"].ToString();
            if (!monthList.ContainsKey(key))
            {
                monthList.Add(key, new List<string>());
            }
            monthList[key].Add(value);
        }
        List<string> b = new List<String>();
        foreach (var month in monthList.Keys)
        {
            b.Add(month + ": " + String.Join(", ", monthList[month])");
        }
