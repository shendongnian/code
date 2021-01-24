    public static bool IsValidDate(string DateStr)
    {
      
        return DateTime.ParseExact(DateStr, "dd/MM/yyyy", null);
    }
