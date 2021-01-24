    public void ProceesData<T>(IList<T> param1, string date1)
    	where T : IProcessable // <-- generic constraint added
    {
    	foreach (var element in param1)
    	{
    		element.isProcessed = true;
    	}
    }
