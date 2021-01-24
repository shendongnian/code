    using ClassAlias = Test.Test;
    using NamespaceAlias = Test;
    					
    public class Program
    {
    	public static void Main()
    	{
    		ClassAlias a = new ClassAlias();
            NamespaceAlias.Test t = new NamespaceAlias.Test();
    	}
    }
    
    namespace Test{
    	public class Test{}
    }
