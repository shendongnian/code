    public interface IDoSomething {
        void DoSomething();
    }
    
    public class Constants {
    	private Constants() {}
    	public const int CONST1 = 0;
    }
    
    public class Class1 : IDoSomething {
    	public void DoSomething() { 
    		Console.Write(Constants.CONST1);
    	}
    }
