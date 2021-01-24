    public string GetSalary()
    {
        CultureInfo inr = new CultureInfo("hi-IN");
        return string.Format(inr, "{0:c}", TotalSalary);
    }
