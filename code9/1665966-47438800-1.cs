    DateTime startDate = DateTime.Today.AddDays(-6);
    public string GetStartDate(string outputFormat)
    {
        return startDate.ToString(outputFormat);
    }
