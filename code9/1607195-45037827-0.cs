    int[] testnummer = { 2,3,5,6};
	chickens = chickens.Select(x => new Chicken(x.Number,x.Status)
				{
				 Status =  testnummer.Contains(x.Number)? "Dead" : x.Status		
				}).ToList(); 
