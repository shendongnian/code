    public class Class1
    {
    	public string Name {get;set;}
    }
	var List1 = new List<Class1>();
	var List2 = new List<string>();
	var result = List1.Where(x=>!List2.Contains(x.Name));
