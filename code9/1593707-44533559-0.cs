    public static string DisplayStatus(decimal? number)
    {
        return number == 1 ? "Active" : "Inactive";
    }
    
    public static decimal ConvertStatus(string status)
    {
        return status == "Active" ? 1 : 0;
    }
