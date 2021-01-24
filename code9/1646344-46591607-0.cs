    void Main()
    {
    	var config = new MapperConfiguration(cfg =>
    	{
    		cfg.CreateMap<Parent, ParentVm>().AfterMap((s, d) =>
    		{
    			foreach (var child in d.Children)
    			{
    				child.ParentId = d.ParentId;
    			}
    		});
    		cfg.CreateMap<Child, ChildVm>();
    	});
    	
    	var mapper = config.CreateMapper();
    
    	var parent = new Parent { ParentId = 1, Children = new List<Child>() };
    	var child1 = new Child { ChildId = 1 };
    	var child2 = new Child { ChildId = 2 };
    	parent.Children.Add(child1);
    	parent.Children.Add(child2);
    	
    	var parentVm = mapper.Map<Parent, ParentVm>(parent);
    	parentVm.Dump();
    }
    
    public class Parent
    {
    	public int ParentId { get; set; }
    	public List<Child> Children { get; set; }
    	// other properties
    }
    
    public class Child
    {
    	public int ChildId { get; set; }
    	// other properties
    }
    
    
    public class ParentVm
    {
    	public int ParentId { get; set; }
    	public List<ChildVm> Children { get; set; }
    	// other properties
    }
    
    public class ChildVm
    {
    	public int ParentId { get; set; }
    	public int ChildId { get; set; }
    	// other properties
    }
