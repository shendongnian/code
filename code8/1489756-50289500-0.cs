	private static void CreateTask(string path, string taskFolder, bool highest)
	{
		var sid = WindowsIdentity.GetCurrent().User.Value;
		var userId = WindowsIdentity.GetCurrent().Name;
		using (var ts = new TaskService())
		{
			var td = ts.NewTask();
			if (highest)
			{
				td.Principal.RunLevel = TaskRunLevel.Highest;
			}
			td.Actions.Add(path, "/a", null);
			td.Triggers.Add(new LogonTrigger { UserId = userId, });
			ts.RootFolder.RegisterTaskDefinition(taskFolder + "MyApp Task-" + sid + (highest ? "h" : ""), td);
		}
	}
