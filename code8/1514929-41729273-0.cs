	var results = new ConcurrentBag<ProcessingResult>();
	
	var files = di.EnumerateFiles("*.pdf").Where(x => x.LastWriteTime.Date == datetime.Date);
	Parallel.ForEach(files, file => {
		var newLocation = CopyToNewLocation(file);
		var processingResult = ExecuteAditionalProcessing(newLocation);
		
		results.Add(processingResult);
	});
