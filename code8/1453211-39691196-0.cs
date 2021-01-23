    using (TaskService taskService = new TaskService())
                {
                    TaskDefinition taskDefinition = taskService.NewTask();
                    taskDefinition.RegistrationInfo.Description = "Does something";
                    taskDefinition.RegistrationInfo.Author = "SYSTEM";
    
                    taskDefinition.Principal.DisplayName = "Testing Display Task Name C#";
                    taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
                    taskDefinition.Principal.GroupId = "Administrators";
                    taskDefinition.Principal.UserId = "ACCOUNT";
                    taskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken;
    
                    taskDefinition.Settings.AllowDemandStart = true;
                    taskDefinition.Settings.AllowHardTerminate = true;
                    taskDefinition.Settings.DisallowStartIfOnBatteries = false;
                    taskDefinition.Settings.DisallowStartOnRemoteAppSession = true;
                    taskDefinition.Settings.Hidden = false;
                    taskDefinition.Settings.RestartCount = 0;
                    taskDefinition.Settings.RunOnlyIfIdle = false;
                    taskDefinition.Settings.RunOnlyIfNetworkAvailable = false;
                    taskDefinition.Settings.StartWhenAvailable = true;
                    taskDefinition.Settings.StopIfGoingOnBatteries = false;
                    taskDefinition.Settings.Volatile = false;
                    taskDefinition.Settings.WakeToRun = false;
    
                    taskDefinition.Actions.Add(new ExecAction("notepad.exe"));
    
                    const string taskName = "Testing TASK";
                    taskService.RootFolder.RegisterTaskDefinition(taskName, taskDefinition);
    
                    taskService.FindTask("Testing TASK").Run();
    
                }
