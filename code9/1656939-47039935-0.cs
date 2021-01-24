    void Main()
    {
    	Mapper.Initialize(cfg =>
    			{
    				cfg.CreateMap<Top, TopDto>().ReverseMap()
    					.ForMember(d => d.Nicks, o=> 
    												{ 
    													o.MapFrom(s => s.Nicks);
    													o.UseDestinationValue(); 
    												});
    			});
    
    	Mapper.AssertConfigurationIsValid();
    
    	var source = new TopDto(new List<string> { "Fernandez", "Others" })
    	{
    		Id = 1,
    		Name = "Charlie"
    	};
    
    
    	var destination = Mapper.Map<Top>(source);
    	
    	destination.Dump();
    
    }
    
    // Define other methods and classes here
    public class Top
    {
    	public Top()
    	{
    	 	Nicks = new List<string>();
    	}
    	
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<string> Nicks { get; }
    }
    
    public class TopDto
    {
    	public TopDto(List<string> nicks)
    	{
    		Nicks = nicks;
    	}
    	
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<string> Nicks { get; private set; }
    }
