	public async Task<Dictionary<string, string[]>> GetTemplates(string showName)
	{
		Dictionary<string, string[]> d = new Dictionary<string, string[]>();
		// Get element collection uri of show "DemoShow"
		var elementCollectionUri = GetElementCollectionUri(vizServiceDocURL, showName);
		var templateCollectionUri = GetTemplateCollectionUri(elementCollectionUri);
		var templateNames = GetListOfTemplateName(templateCollectionUri);
		//get the name and links from each show and add them to the dictionary
		// Keep a temporary List of Tasks
		List<Task> allTasks = new List<Task>();
		foreach (string templateName in templateNames)
		{
			string localTemplateName = templateName;
			// Apply our logic and add to our Dictionary in a task
			Task jobTask = Task.Run(() => 
			{
				var templateCollectionEntryUri = GetTemplateCollectionEntryUri(templateCollectionUri, localTemplateName);
				var elementModelUri = GetTemplateElementModelUri(templateCollectionUri, localTemplateName);
				string[] links = new string[2] { templateCollectionEntryUri, elementModelUri };
				d.Add(localTemplateName, links);
			});
			
			// Add the task to our temp collection
			allTasks.Add(jobTask);
		}
		
		// Wait for all tasks to finish, WhenAll is non-blocking unlike WaitAll.
		await Task.WhenAll(allTasks);
		
		return d;
	}
