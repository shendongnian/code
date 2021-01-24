    public List<SomeObject> MergeObj(List<SomeObject> someObjects)
    	{
    		var idList = someObjects.Select(x => x.Id).Distinct().ToList();
    		var newSomeObjects = new List<SomeObject>();
    		idList.ForEach(x =>
    		{
    			var newValuePairList = new List<KeyPair>();
    			someObjects.Where(y => y.Id == x).ToList().ForEach(y =>
    			{
    				newValuePairList.AddRange(y.ValuePairs);
    			});
    			newSomeObjects.Add(new SomeObject{Id = x, ValuePairs = newValuePairList});
    		});
    		
    		return newSomeObjects;
    	}
