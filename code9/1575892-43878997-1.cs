    foreach (string row in columns)
    {
        string data = row;
        string regex = @"((-|)\b\d[\d,.\/]*\b)";
        var matches = Regex.Matches(data, regex, RegexOptions.Multiline);
        int Id = Convert.ToInt16(matches[1].Groups[0].ToString().Replace(",", ""));
        decimal Amount = Convert.ToDecimal(matches[0].Groups[0].ToString());
        DateTime date = Convert.ToDateTime(matches[2].Groups[0].ToString());
        string name = Regex.Replace(data, regex, "").ToString().Trim();
        datarow["Id"] = Id;
        datarow["Amount"] = Amount;
        datarow["date"] = date;
        datarow["name"] = name;
        datatable.Rows.Add(datarow);
    }
 
