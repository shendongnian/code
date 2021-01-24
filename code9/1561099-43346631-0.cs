    void Main()
    {
    	var someObjects = new List<ObjectClass>();
    	
    	someObjects.Add(new ObjectClass(){ Value = 2});
    	someObjects.Add(new ObjectClass(){ Value = 3});
    	someObjects.Add(new ObjectClass(){ Value = 4});
    	
    	int sumOfValues = someObjects.Sum(i=>i.Value);
    }
    
    public class ObjectClass
    {
      public int Id;
      public string Name;
      public int Value;
    }
