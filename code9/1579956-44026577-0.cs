    public static int Compare(object value1, object value2)
    {
        if (value1 is double || value2 is double)
        {
            double d1 = Convert.ToDouble(value1);
            double d2 = Convert.ToDouble(value2);
            return d1.CompareTo(d2);
        }
        if (value1 is float || value2 is float)
        {
            float f1 = Convert.ToSingle(value1);
            float f2 = Convert.ToSingle(value2);
            return f1.CompareTo(f2);
        }
        long x1 = Convert.ToInt64(value1);
        long x2 = Convert.ToInt64(value2);
        return x1.CompareTo(x2);
    }
