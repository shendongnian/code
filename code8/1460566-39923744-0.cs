    private List<Processo> removeFromListRepeats(List<Processo> processosComp)
    {
	    Dictionary<int, Processo>  dict = new Dictionary<int, Processo>();
    	foreach (var item in processosComp)
	    {
		    Processo existingRecord ;
		    if (!dict.TryGetValue(item.iNumProcesso , out existingRecord)) 
			    dict.Add(item.iNumProcesso , item);			
	    }
	    return dict.Values.ToList();
    }
 
