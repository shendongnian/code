    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		Customer C1 = new Customer("Bob", "Robert", "BobyBob 23, 41423");
    		C1.PrintFullName();
    		C1 = new Customer("Bob", "Robert");
    		C1.PrintFullName();
    	}
    }
    
    class Customer
    {
    	
    	string _firstName;
    	string _lastName;
    	string _address;
    	
    
    	public Customer()
    	{
    		Console.WriteLine("I'm the last one :)");
    		Console.WriteLine("Full Name is {0}", this._firstName+" "+this._lastName);
    	}
    	
    	public Customer(string FirstName, string LastName) : this()
    	{
    		Console.WriteLine("I'm gonna call the constructor within the same class that has no parameters.");		
    		_firstName = FirstName;
    		_lastName = LastName;
    	}
    	
    	public Customer(string FirstName, string LastName, string address) : this(FirstName, LastName)
    	{
    		Console.WriteLine("I'm gonna call the constructor within the same class that has 2 parameters that are of type string.");
    		_address = _address;
    	}
    	
    	public void PrintFullName()
    	{
    		Console.WriteLine("Full Name is {0}", this._firstName+" "+this._lastName);
    	}
    }
