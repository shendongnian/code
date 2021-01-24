    string value = "1";
    
    if (!string.IsNullOrEmpty(value) &&
         value.Length == 1 && 
         Enum.GetValues(typeof(MyEnum)).Cast<int>().Any(item => item == value[0])) {
      Console.WriteLine("Valid");
    }
