	public async Task<bool> MyMethod()
	{
		var tcs = new TaskCompletionSource<bool>();
		_databaseService.OpenConnection();
		var dataCount = 0;
		_dataService.QuerySegmentedObservable<TSource>(_sourceTableName)
			.SelectMany(async data =>
			{
				await _databaseService.DoSomething(data);
				return data;
            })
			//.Finally(() => _databaseService.CloseConnection()) //This would be called on OnComplete and OnError, just like try-finally
			.Subscribe(data =>
				{
					dataCount += data.Count;
		
					Console.WriteLine($"Processing - {dataCount}");
				},
				err =>
				{
					Console.WriteLine($"Error - {err.Message}");
					tcs.SetResult(false);
				},
				() =>
				{
					_databaseService.CloseConnection(); //Maybe move this to a Finally call?
					Console.WriteLine($"Finished");
					tcs.SetResult(true);
				}
			);
	
		return await tcs.Task;
	}
