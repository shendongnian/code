    public static DateTime? DateFromString(string value)
    {
      
        DateTime? date;
        string[] formats = { "dd/MM/yyyy"};
        DateTime.TryParseExact(value, formats, 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date);
        return date;
    }
    DateTime? date=DateFromString(e.Record["CHEQUE_DT"];
    drExpInfo[0]["CHEQUE_DT"] = date==null? DBNull.Value : (object)date);
        
