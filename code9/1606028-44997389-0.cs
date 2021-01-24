    namespace ClassLibrary2
    {
    	public class TestClass
    	{
    		public abstract class BaseClass<T> where T : BaseClass<T> {}
    
    		public class Class1 { }
    
    		public class Class2 : BaseClass<Class2> { }
    
    		private class Dictionary : Dictionary<Class1, Class2> { }
    
    		public void Test()
    		{ 
    			var dictionary = new Dictionary { { new Class1(), new Class2() } };
    		}
    	}
    }
