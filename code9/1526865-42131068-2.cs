    public class Class1
    {
    	public string Property1 {get;set;}
    	public string Property2 {get;set;}
    }
	var ListOfObject = new List<Class1>
	{
		new Class1{Property1 = "A1", Property2 = "X1"},
		new Class1{Property1 = "B1", Property2 = "Y1"},
		new Class1{Property1 = "A1", Property2 = "Z1"},
		new Class1{Property1 = "B1", Property2 = "Y1"},
	};
	
