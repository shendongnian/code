    public static void Main()
    {
       var enumType = typeof(Foo<>.Bar);
       foreach(var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
       {
           Console.WriteLine(field.Name);
       }
    }
