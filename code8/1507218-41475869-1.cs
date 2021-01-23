    void SomeMethod<T>(IEnumerable<T> originalTypedArray, int MyId) 
    	where T : class, IMyInterface
    //  ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ this is important 
    {
    	if (originalTypedArray != null)
    	{
    		var filteredArray = originalTypedArray.Where(r => r.Ids.Contains(MyId));
    		
            // No need to cast to `IEnumerable<T>` here - we already have ensured covariance
            // is valid in our generic type constraint
    		DoSomethingExpectingIEnumerableOfIMyInterface(filteredArray);
    	}
    }
    void DoSomethingExpectingIEnumerableOfIMyInterface(IEnumerable<IMyInterface> src)
    {
    	foreach (var thing in src)
    	{
    		
    	}
    }
