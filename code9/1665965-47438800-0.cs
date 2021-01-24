    DateTime startDate = DateTime.Today.AddDays(-6);
    public string GetStartDate(outputFormat)
    {
        return startDate.ToString(outputFormat);
    }
