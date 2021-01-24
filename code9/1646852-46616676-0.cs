                    int numberOfProcess = 3;
                    Task[] _tasks = new Task[numberOfProcess];
    
                    for (int i = 1; i <= numberOfProcess; i++)
                    {
    					string[] args = new string[2];
    					args[0] = minSlNo.ToString();
    					args[1] = nextSlno.ToString();                     
    
    					_tasks[i - 1] = Task.Factory.StartNew(() =>
    					{
    						//do the required work
    						DoWork(args);
    					});
    
    					System.Console.WriteLine("Min =" + minSlNo + "  Next Msg=" + nextSlno);
    					SetLogFilesProperty("BatchJob_Start", args[0].ToString() + "_" + args[1].ToString());                    
                    }
    
                    while (_tasks.Any(t => !t.IsCompleted)) 
                    {//execution waits till all the tasks are completed  
                    }
    
                    Console.Write("All Tasks Completed"+DateTime.Now);
