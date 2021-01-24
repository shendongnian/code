    String date = (dr["DateCreated"] ?? String.Empty).ToString();
    
    if (!String.IsNullOrEmpty(date))
    {
        date = date.Insert((date.Length - 5), "+");
        // NB: Convert.ToDateTime will give same value as DateTime.ParseExact here
        DateTime? dateCreated = DateTime.ParseExact(date, "yyyy-MM-ddTHH:mm:ss.FFFFFFF zzzz", 
                                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
    }
