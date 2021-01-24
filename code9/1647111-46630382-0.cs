    static void Main()
    {
    	Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<Kempe, KempeList>();
            cfg.CreateMap<List<Kempe>, KempeCollector>()
    			.ForMember(d=>d.Collection, o=>o.MapFrom(s=>s));
        });
    	Mapper.AssertConfigurationIsValid();	
    	var kList = new List<Kempe>{new Kempe{ Name = "1000", DateTaken = DateTime.Today, Score = 1 }, new Kempe{ Name = "3000", DateTaken = DateTime.Today.AddDays(2), Score = 2 }};
        var kColl = Mapper.Map<KempeCollector>(kList).Dump();
    }
    
    public class Kempe
    {
       public string Name {get; set;}
       public DateTime DateTaken {get; set;}
       public decimal Score {get; set;}
    }
    
    public class KempeCollector
    {
       public string FirstName {get; set;}
       public List<KempeList> Collection {get; set;}
    }
    
    public class KempeList 
    {
       public DateTime DateTaken {get; set;}
       public decimal Score {get; set;}
    }
