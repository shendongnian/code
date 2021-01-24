    public class MyClass
    {
       public static implicit operator MyClass (int val)
       {
           return new MyClass { Value = new String('!', val)};
       }
       public string Value {get;set;}
    }
