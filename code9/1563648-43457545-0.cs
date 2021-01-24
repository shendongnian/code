    public static DateTime ParseExcelDate(this string date, SqlDbType type)
            {
                if (date.Equals("null", StringComparison.InvariantCultureIgnoreCase) || date.Equals("1.0"))
                    return new DateTime(1900, 01, 01);
    ...
