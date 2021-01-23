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
	        return result.Select(r=>r.MVE).ToList();
       }
     }
