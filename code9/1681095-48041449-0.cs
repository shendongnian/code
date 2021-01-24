       public Task<int> Launch(string Path, string iniFilePath)
                {
                    try
                    {
                        TaskService taskService = new TaskService();
        
                        const string TaskName = "LaunchTask";
                        if (taskService.FindTask(TaskName) != null)
                        {
                            var task = taskService.FindTask(TaskName);
                        }
        
                    iniFilePath = "\"" + iniFilePath + "\"";
                    string completeArgument = "/portable /skipupdate " + iniFilePath;
                    TaskDefinition taskDefinition = taskService.NewTask();            
                    taskDefinition.Principal.LogonType = TaskLogonType.ServiceAccount;
                    taskDefinition.Principal.UserId = @"NT AUTHORITY\NETWORKSERVICE";
                    taskDefinition.Actions.Add(new ExecAction(mt4Path, completeArgument, null));                          
                    taskDefinition.Settings.Hidden = false;
                    Microsoft.Win32.TaskScheduler.Task mtTask = taskService.RootFolder.RegisterTaskDefinition(TaskName, taskDefinition);
                    RunningTask runningMT4 = mtTask.Run();
                    int processIdMT = (int)runningMT.EnginePID;
                    mt4Task.Folder.DeleteTask(mtTask.Name);
                    return System.Threading.Tasks.Task.FromResult(processIdMT);
                }
                catch
                {
                    throw;
                }
            }
