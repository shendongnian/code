    public static void Main()
    {
       var enumType = typeof(Foo<>.Bar);
       var underlyingType = Enum.GetUnderlyingType(enumType);
       foreach(var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
       {
           var value = field.GetValue(null);
           var underlyingValue = Convert.ChangeType(value, underlyingType);
           Console.WriteLine($"{field.Name} = {underlyingValue}");
       }
    }
