    List<string> salaryList = new List<string>();
    while(DRhistory.Read())
    {
        salaryList.Add(DRhistory.GetString(0));
    }
