    static public object ToDbNullableDate(this string s)
    {
        DateTime d;
        var ok = DateTime.TryParse(s, out d);
        return ok ? d : DbNull.Value;
    }
