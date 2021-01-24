    System.Threading.Tasks.Task task = null;
			if (task==null)
			{
				task = Task.Factory.StartNew(() =>
				{
					beginTask();
                    
				});
                return;
			}
			if (task.Status == TaskStatus.Running)
			{
				task.ContinueWith((x) =>
				{
					beginTask();
				});
			}else
			{
				task = Task.Factory.StartNew(() =>
				{
					beginTask();
				});
			}
