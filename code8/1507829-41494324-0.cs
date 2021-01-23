    DateTime startDate = new DateTime();
    DateTime endDate = new DateTime();
    string startDateString
    {
        get
        {
            return startDate.ToShortDateString();
        }
    }
    string endDateString
    {
        get
        {
            return endDate.ToShortDateString();
        }
    }
    
    private void LoadMethod()
    {
        startDate = (DateTime)row["Course_StartDate"];
        endDate = (DateTime)row["Course_EndDate"];
    }
