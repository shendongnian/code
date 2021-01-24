    void Main()
    {
    	List<BaseClass> authenticators = new List<UserQuery.BaseClass>();
    	authenticators.Add(new ConcreteClassA());
    	authenticators.Add(new ConcreteClassB());
    	foreach (var authenticator in authenticators)
    	{
    		authenticator.TemplateMethod();
    	}
    }
    
    
    public abstract class BaseClass
    {
    	public abstract void Operate();
    	
    	public void AuthenticateSuccessfully()
    	{
    		Console.WriteLine("Base Class Authentication");
    		// Do Stuff Specific to base class
    	}
    	
    	public void TemplateMethod()
    	{
    		Console.WriteLine("Template method called");
    		Operate();
    		AuthenticateSuccessfully();
    	}
    }
    
    public class ConcreteClassA : BaseClass
    {
    	public override void Operate()
    	{
    		Console.WriteLine("Operate Method of ConcreteClassA");
    	   //Do Whatever here Specific to the Concrete class A
    	}
    }
    
    class ConcreteClassB : BaseClass
    {
    	public override void Operate()
    	{
    		Console.WriteLine("Operate Method of ConcreteClassB");
    		//Do Whatever here Specific to the Concrete class B
    	}
    }
