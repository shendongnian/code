    int i = 0;
    int j = 0;
    var rows = list.Select(exam =>
    {
    
        string inclusiveDates = string.Format("{0} - {1}", GetDateTime(exam.IDAFrom), GetDateTime(exam.IDATo));
        return new
        {
            Id = ++i,
            Cell = new object[] { ++j, inclusiveDates }
        };
    })
    .ToList();
