    public async Task<LinkedList<string>> ReadDataAsync()
    {
    var docs = new LinkedList<string>();
	
	List<Task<string>> taskList =  new List<Task<string>>();
	for (int i = 0; ; ++i) // Set a limit to i, since you are not running synchronously, so you cannot keep checking which value yields null as result
	{
		int localId = i;
		taskList.Add(ReadData(localId));
	}
     await Task.WhenAll(taskList);
     // Do Link List processing, if the Task is not cancelled and doesn't have an error, then result can be accessed
    }
