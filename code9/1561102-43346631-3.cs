    void Main()
    {
    	var someObjects = new List<ObjectClass>();
    	
    	someObjects.Add(new ObjectClass(){Name="numberWang", Value = 2});
    	someObjects.Add(new ObjectClass(){Name="numberWang", Value = 3});
    	someObjects.Add(new ObjectClass(){Name="numberTwang", Value = 4});
    	someObjects.Add(new ObjectClass(){Name="numberTwang", Value = 5});
    
    	//You could filter this beforehand with a Where clause ie. someObjects.Where(i=>i.Name == "whatever").Sum(i=>i.Value)
    	int sumOfValuesOfAllObjects = someObjects.Sum(i=>i.Value);
    		
    	var sumByObjectClassName = someObjects.GroupBy(a=>a.Name).Select(b=>
    	new ObjectClass() { Name = b.First().Name, Value =b.Sum(c=>c.Value) } );
    }	
    
    public class ObjectClass
    {
      public string Name;
      public int Value;
    }
