    void Main()
    {
    	var list = new List<MinifiedSiteEvent>{
    		new MinifiedSiteEvent{ A = 1, B = 1, C = 1, D = 1, E = 1, F = 1 },
    		new MinifiedSiteEvent{ A = 2, B = 2, C = 2, D = 2, E = 2, F = 2 },
    		new MinifiedSiteEvent{ A = 3, B = 3, C = 3, D = 3, E = 3, F = 3 },
    	};
    
    	var filter1 = 2;
    	var filter2 = 3;
    	
    	var result = list.Where(x => x.IsInRange(filter1, filter2) );		
    }
    
    class MinifiedSiteEvent
    {
    	public int A { get; set; }
    	public int B { get; set; }
    	public int C { get; set; }
    	public int D { get; set; }
    	public int E { get; set; }
    	public int F { get; set; }
    	
    	public bool IsInRange(int item1, int item2)
    	{
    		return A >= item1 && A <= item2
    			&& B >= item1 && B <= item2
    			&& C >= item1 && C <= item2
    			&& D >= item1 && D <= item2
    			&& E >= item1 && E <= item2
    			&& F >= item1 && F <= item2;
    	}
    }
