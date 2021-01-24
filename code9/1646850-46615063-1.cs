      static object _lock = new object();
            static List<string> myList = new List<string>();
            TaskFactory TaskFac = new TaskFactory();
       
    
            static void Main(string[] args)
            {
                //Run the whole operation both threads and task.
                Operation();
            }
            static async void Operation()
            {
                Task t = Task.Run(new Action(RunThreads)).ContinueWith(o => {
    
                    WriteMessage();
    
    
                });
                t.Wait();
    
                Console.ReadKey();
    
                //Write the result.
                //  WriteMessage();
            }
            static void RunThreads()
            {
                //Read thread1.
                string threadName = "Thread-1";
                Thread thread1 = new Thread(() =>
                {
    
                    for (int i = 1; i < 11; i++)
                    {
                        DoSomething(
    
                        threadName, i
    
    
                        );
                    }
    
                });
                thread1.Start();
    
                string threadName1 = "Thread-2";
                Thread thread2 = new Thread(() => { 
                 for (int i = 1; i < 11; i++)
                {
                    DoSomething(
    
                    threadName1, i
    
    
                    );
                } });
                thread2.Start();
    
                
          
            }
            public static void DoSomething(string threadName,int loop_index)
            {
                Monitor.Enter(_lock);
                {
                    
                        myList.Add(string.Format("{0} from thread: {1}",loop_index, threadName));
                    
                    Monitor.Exit(_lock);
                }
              
            }
    
            private static void WriteMessage()
            {
                foreach (string val in myList)
                {
                    Console.WriteLine(val);
                }
                Console.Read();
            }
