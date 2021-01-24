    using Microsoft.Win32.TaskScheduler;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CreateTaskTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                addTask();
                //deleteTask();
            }
    
            static void addTask()
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition and assign properties
                    TaskDefinition newTask = ts.NewTask();
                    newTask.RegistrationInfo.Description = "Rondinelli Morais Create Task";
    
                    newTask.Triggers.Add(new LogonTrigger());
    
                    newTask.Actions.Add(new ExecAction("C:\\Windows\\regedit.exe"));
    
                    newTask.Principal.RunLevel = TaskRunLevel.Highest;
                    newTask.Principal.LogonType = TaskLogonType.InteractiveToken;
    
                    newTask.Settings.Compatibility = TaskCompatibility.V2_1;
                    newTask.Settings.AllowDemandStart = true;
                    newTask.Settings.DisallowStartIfOnBatteries = false;
                    newTask.Settings.RunOnlyIfIdle = false;
                    newTask.Settings.StopIfGoingOnBatteries = false;
                    newTask.Settings.AllowHardTerminate = false;
                    newTask.Settings.UseUnifiedSchedulingEngine = true;
                    newTask.Settings.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
    
                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(@"Test", newTask);
    
                    newTask.Dispose();
                    ts.Dispose();
                }
            }
    
            static void deleteTask()
            {
                using (TaskService ts = new TaskService())
                {
    
                    var tasks = ts.FindAllTasks(new System.Text.RegularExpressions.Regex(@"Test"));
    
                    foreach(var task in tasks){
                        ts.RootFolder.DeleteTask(task.Name);
                    }
                }
            }
        }
    }
