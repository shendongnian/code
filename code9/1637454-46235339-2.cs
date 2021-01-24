	for (int count = 0; count < 3; count++)
    {
        int scopeCount = count;
        var d = System.Threading.Tasks.Task.Run(async () => {
			await SampleAsyncMethodAsync(1, scopeCount.ToString());
			await SampleAsyncMethodAsync(2, scopeCount.ToString());
			await SampleAsyncMethodAsync(3, scopeCount.ToString());
		});
    }	
