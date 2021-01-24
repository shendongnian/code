                foreach (var bgTask in BackgroundTaskRegistration.AllTasks)
                {
                    if (bgTask.Value.Name == "MaintenanceTask")
                    {
                        bgTask.Value.Unregister(true);
                    }
                }
    
                var requestTask = BackgroundExecutionManager.RequestAccessAsync();
                var builder = new BackgroundTaskBuilder();
    
                builder.Name = "MaintenanceTask";
                builder.TaskEntryPoint = "BackgroundTasks.MaintenanceTask";
                builder.SetTrigger(new MaintenanceTrigger(360, false));
                BackgroundTaskRegistration task = builder.Register();
