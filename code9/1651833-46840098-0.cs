    public override bool IsValid(object value)
    {
        DateTime date;
        try
        {
            if (DateTime.TryParse(value.ToString(), out date))
                return date.AddYears(_minimumAge) < DateTime.Now;
        }
        catch (Exception) {  }
        return false;
    }
