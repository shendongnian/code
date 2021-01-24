    static HashSet<int> s_Valids = new HashSet<int>(Enum
      .GetValues(typeof(MyEnum))
      .Cast<int>());
    ...
    string value = "1";
    
    if (!string.IsNullOrEmpty(value) &&
         value.Length == 1 && 
         s_Valids.Contains(value[0])) {
      Console.WriteLine("Valid");
    }
