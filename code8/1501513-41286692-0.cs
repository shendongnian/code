      private bool cachedResult;
	  protected bool CachedResult
	  {
		  get { return cachedResult ?? (cachedResult = ComplicatedCalculation()); }
	  }
...
    if(CachedResult)
    {
    ...
    }
