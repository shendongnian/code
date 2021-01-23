    public static DateTime? DateFromString(string value)
    {
       if (string.IsNullOrWhiteSpace(value))
         {
           return null;
         }
       else
         {
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
         }
    }
    DateTime? date=DateFromString(e.Record["CHEQUE_DT"]);
    drExpInfo[0]["CHEQUE_DT"] = date==null? DBNull.Value : (object)date);
        
