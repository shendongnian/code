    void Main()
    {
    	Mapper.Initialize(cfg =>
    	{
    		cfg.CreateMap<A, MA>().PreserveReferences();
    		cfg.CreateMap<B, MB>().PreserveReferences();
    	});
    	
    	var b = new B();
    	var a1 = new A() { Ref = b };
    	var a2 = new A() { Ref = b };
    	
    	var ma = Mapper.Map<MA[]>(new[]{a1, a2});
    	(ma[0] == ma[1]).Dump();
    	(ma[0].Ref == ma[1].Ref).Dump();
    }
    
    class A { public B Ref { get; set; } }
    class B { }
    
    class MA { public MB Ref { get; set; } }
    class MB { }
