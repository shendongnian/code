    void Main()
    {
	
	    BaseTest test = new TestClass();
	    var attr = (MyAttribute) test.GetType().GetCustomAttributes().First();	
	    attr.Id = 34;
	
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class MyAttribute : Attribute
    {	
	    public int Id { get; set; } = 3;	
    }
    public class BaseTest { }
    [My]
    public class TestClass : BaseTest { }
