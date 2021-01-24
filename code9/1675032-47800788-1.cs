    void Main()
    {
    	var test = new Animal();
    	test.Name.Dump();
    	test.Name = "new name 1";
    	test.Name.Dump();
    	test.Rename("new name 2");
    	test.Name.Dump();
    }
    
    // Define other methods and classes here
    class Animal
    {
    	public string Name { get { return name; } set { name = value; } }
        // Remove the setter here if you don't want to allow assignment through Name
        // e.g. public string Name { get { return name; } }
    	private string name;
    	public void Rename(string NewName)
    	{
    		name = NewName;
    	}
