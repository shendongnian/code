    ValidationMessage Test()
     {
      List<IValidatable> items = new List<IValidatable>();
      MyClass1 item1 = new MyClass1();
      MyClass2 item2 = new MyClass2();
      items.Add(item1);
      items.Add(item2);
      ValidationMessage result = null;
      foreach (var i in items)
      {
        result = i.ValidateItem();
        if (!result.Success) break;
      }
      return result;
    }
    interface IValidatable
    {
      ValidationMessage ValidateItem();
    }
    public class ValidationMessage
    {
      public bool Success { get; set; }
      public string ErrorMessage { get; set; }
    }
    public class MyClass1 : IValidatable
    {
      public ValidationMessage ValidateItem()
      {
        return new ValidationMessage();
      }
    }
    public class MyClass2 : IValidatable
    {
      public ValidationMessage ValidateItem()
      {
        return new ValidationMessage();
      }
    }
