    void Main()
    {
    	Person A = new Person()
    	{
    		Name = "John",
    		Surname = "Doe"
    	};
    
    	Person B = new Person()
    	{
    		Name = "Jane",
    		Surname = "Doe"
    	};
    
    	A.ShowInfo();
    	Console.WriteLine("----");
    	B.ShowInfo();
    }
    
    class Person
    {
    	public string Name { get; set; }
    	public string Surname { get; set; }
    
    	public void ShowInfo()
    	{
    		Debug.WriteLine("Name=" + Name);
    		Debug.WriteLine("Surname=" + Surname);
    	}
    }
