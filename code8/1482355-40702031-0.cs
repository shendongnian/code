    public class Source
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public class Destination
    {
    	public string Name1 { get; set; }
    	public string Name2 { get; set; }
    	public string Name3 { get; set; }
    }
    
    Mapper.CreateMap<Source[], Destination>()
    	.ForMember(d => d.Name1, o => o.MapFrom(s => s.First(x => x.Id == 1).Name))
    	.ForMember(d => d.Name2, o => o.MapFrom(s => s.First(x => x.Id == 2).Name))
    	.ForMember(d => d.Name3, o => o.MapFrom(s => s.First(x => x.Id == 3).Name));
