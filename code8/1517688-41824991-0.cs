    public static DateTime? DateFromString(string value)
    {
      
     DateTime date;
        string[] formats = { "dd/MM/yyyy"};
        DateTime.TryParseExact(value, formats, 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date);
     return date;
    }
    drExpInfo[0]["CHEQUE_DT"] = string.IsNullOrWhiteSpace(e.Record["CHEQUE_DT"].ToString())
        ? DBNull.Value : (object)DateFromString(e.Record["CHEQUE_DT"]);
