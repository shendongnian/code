    public List<string> Search(string quickSearchText)
    {
       using(var ctx=new model()))
       {
	       var result=ctx
		          .Vw_VehicleSearch
		          .Where(v=>v.MVE.Contains(quickSearchText)
		           || v=>v.MEV.Contains(quickSearchText)
		          .|| v=>v.VME.Contains(quickSearchText)
		          .|| v=>v.VEM.Contains(quickSearchText)
		          .|| v=>v.EMV.Contains(quickSearchText)
		          .|| v=>v.EVM.Contains(quickSearchText)
		          .ToList();
             
            //here you can do some sort of ranking for the result and return 
            //the top result, as you have already fetched all records, there
            //will be no more db round trips                      
	        return result.Select(r=>r.MVE).ToList();
       }
     }
