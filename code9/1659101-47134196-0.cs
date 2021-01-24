    public static void method1(Type convertTo, object toBeConverted)
    {
        var convertedValue = Convert.ChangeType(toBeConverted,convertTo);
    }
    
    public static void method2<TConvert>(object toBeConverted)
    {
        var convertedValue = (TConvert)toBeConverted;
    }
