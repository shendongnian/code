    void Main()
    {
    	SampleClass classWithValues = new SampleClass();
    	var listComponent = new Components();
    	listComponent.Add(new Component{Name = "Random string",Age = "31"});
    	classWithValues.Components = listComponent; 
    	classWithValues.Name = "TestName";
    	
    	var listWithObjectClass = new List<SampleClass>();
    	listWithObjectClass.Add(classWithValues);
    
    	SampleClass classWithValues1 = new SampleClass();
    	var listComponent1 = new Components();
    	listComponent1.Add(new Component{Name = "Random string",Age = "31"});
    	classWithValues1.Components = listComponent1; 
    	classWithValues1.Name = "TestName";
    
    	bool alreadyExists = listWithObjectClass.Any(x => x.Components.Equals(classWithValues1.Components));
    }
    
    public class SampleClass
    {
        public string Name { get; set; }
        public Components Components { get; set; }
    }
    
    public class Component : IEquatable<Component>
    {
        public string Name { get; set; }
        public string Age{ get; set; }
    	
    	public bool Equals(Component otherComponent)
    	{
    		return Name == otherComponent.Name && Age == otherComponent.Age;
    	}
    }
    
    public class Components :List<Component>, IEquatable<Components>
    {
    	public bool Equals(Components otherComponents)
    	{
    		if(this.Count!= otherComponents.Count) return false;
    		
    		return this.TrueForAll(a=> otherComponents.Any(q=>q.Equals(a)))
    		&& otherComponents.TrueForAll(a=> this.Any(q=>q.Equals(a)));
    	}
    }
