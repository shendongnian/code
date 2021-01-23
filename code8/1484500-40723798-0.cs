    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AttBase : Attribute 
    {
       public IndicatorType Indicator {get;set;}
       public AttBase(IndicatorType indicator )
       {
          Indicator = indicator;
       }
    }
        
    public enum IndicatorType 
    {
      Foo,
      Bar,
    }
    
    public class MyClass
    {
        [AttBase(IndicatorType.Foo)]
        public string MyProperty { get; set; }
    }
