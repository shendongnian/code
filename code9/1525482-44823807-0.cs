    var task = (Task) client.GetView(cloneTask_MoRef, null);
	while (task.Info.State != TaskInfoState.success)
	{
		Thread.Sleep(5000);
		task.UpdateViewData();
		if (task.Info.State == TaskInfoState.error)
			throw new Exception($"The clone failed: {task.Info.Error.LocalizedMessage}");
        
		Console.WriteLine(task.Info.Progress);
	}
