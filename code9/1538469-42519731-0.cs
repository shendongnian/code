    public class Parent
        {
            private readonly List<Child> _children = new List<Child>();
        
            public readonly ReadOnlyCollection<Child> Children = _children.AsReadOnly();
        	
        	public void Remove(Child child)
        	{
        		if(child !=null) 
        		{
        		 _children.Remove(child);
        		}
        	}
        }
