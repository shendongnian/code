    System.Reflection.MemberInfo info = typeof(MyClass);
    object[] attributes = info.GetCustomAttributes(true);
    for (int i = 0; i < attributes.Length; i ++)
    {
        System.Console.WriteLine(attributes[i]);
    }
