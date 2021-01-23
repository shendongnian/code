    public class MyCustomAttribute : Attribute
    {
        public int[] Values { get; set; } = new int[] { 1, 2, 3 };
    
        public MyCustomAttribute(params int[] values)
        {
            this.Values = values;
        }
    }
    
    [MyCustom(1, 2, 3)]
    class MyClass
    {
    
    }
    
    [MyCustom(Values = new int[] { 1, 2, 3})]
    public class MyAnotherClass
    {
    }
