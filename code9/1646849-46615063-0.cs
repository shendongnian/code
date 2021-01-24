      static List<string> myList = new List<string>();
            static void Main(string[] args)
            {
                //Run the whole operation both threads and task.
                Operation();
            }
            static async void Operation()
            {
                Task t = Task.Run(new Action(RunThreads)).ContinueWith(o=> {
    
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
                Thread thread1 = new Thread(() => DoSomething(threadName));
                thread1.Name = threadName;
                thread1.Start();
    
                //Read thread2.
                threadName = "Thread-2";
                Thread thread2 = new Thread(() => DoSomething(threadName));
                thread2.Name = threadName;
                thread2.Start();
            }
            public static void DoSomething(string threadName)
            {
                for (int i = 1; i < 10; i++)
                {
                    myList.Add(string.Format("{0} from thread: {1}", i, threadName));
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
