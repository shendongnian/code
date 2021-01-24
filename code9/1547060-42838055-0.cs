	TaskCompletionSource<SystemComponentMode.AsyncCompletedEventArgs> tcs = 
        new TaskCompletionSource<SystemComponentMode.AsyncCompletedEventArgs>();
	EditableListConfigurationObject<UserConfiguration.Property>
        .CommitAsync((sender,args) => {
		    tcs.SetResult(args); //or perhaps tcs.SetException in some cases?
	    }, object userState);
	var resultArgs = await tcs.Task;
