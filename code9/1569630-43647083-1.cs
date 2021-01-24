    void Main()
    {
    	var authenticators = new List<UserQuery.BaseClass>();
    	authenticators.Add(new ConcreteClassA());
    	authenticators.Add(new ConcreteClassB());
    	foreach (var authenticator in authenticators)
    	{
    		authenticator.TemplateMethod();
    	}
    }
    
    
    public abstract class BaseClass
    {
    	public abstract void Validate();
    	
    	public void AuthenticateSuccessfully()
    	{
    		Console.WriteLine("Base Class Authentication");
    		// Do Stuff Specific to base class
    	}
    	
    	public void TemplateMethod()
    	{
    		Console.WriteLine("Template method called");
    		Validate();
    		AuthenticateSuccessfully();
    	}
    }
    
    public class ConcreteClassA : BaseClass
    {
    	public override void Validate()
    	{
    		Console.WriteLine("Validate Method of ConcreteClassA");
    	   //Do Whatever here Specific to the Concrete class A
    	}
    }
    
    class ConcreteClassB : BaseClass
    {
    	public override void Validate()
    	{
    		Console.WriteLine("Validate Method of ConcreteClassB");
    		//Do Whatever here Specific to the Concrete class B
    	}
    }
