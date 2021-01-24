    private static DateTime _sqlDefaultDateTime = new DateTime(1753, 01, 01);
    
    private void foo()
    {
        string parsedDate;
        if (!DateTime.TryParseExact())
        {
            parsedDate = _sqlDefaultDateTime;
        }
    }
