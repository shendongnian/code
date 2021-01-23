    public List<EntityDto> GetMyData(string condition)
    {
    	var sourceEntityList = new List<Entity>().AsQueryable();
    	switch (condition)
    	{
    		case "A":
    			return sourceEntityList.Where(x => x.Name == "A")
    				.Select(CustomSelector(x => sourceEntityList.Where(y => y.Name == x.Name))).ToList();
    		case "B":
    		default:
    			return sourceEntityList.Where(x => x.Name == "B")
    				.Select(CustomSelector(x => sourceEntityList.Where(y => y.Name != x.Name))).ToList();
    	}
    }
