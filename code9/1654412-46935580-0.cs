    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    namespace ConcurrentCollectionTest
    {
        internal class Client
        {
            public string State
            {
                get; set;
            }
            public string Name
            {
                get;
                internal set;
            }
        }
    
        internal class MainWindow
        {
            private ConcurrentDictionary<int, Client> _dict = new ConcurrentDictionary<int, Client>();
    
            public IDictionary<int, Client> Clients
            {
                get
                {
                    return _dict;
                }
            }
        }
    
        internal class Program
        {
            private static bool killAll = false;
            private static MainWindow mainWindow = new MainWindow();
            private static int id = -100;
            private static string state = "Initial";
            private static Random random = new Random();
    
            internal static string RandomString(int v)
            {
                int k = random.Next(0, v);
                return k.ToString();
            }
    
            public static void RunChild()
            {
                Debug.WriteLine($"child running {Thread.CurrentThread.Name}");
                bool killThis = false;
                while (!killThis && !killAll)
                {
                    Thread.Sleep(100);
                    Client client = null;
                    if (mainWindow.Clients.TryGetValue(id, out client))
                    {
                        state = client.State;
                    }
    
                    Thread.Sleep(random.Next(50));
    
                    if (random.Next(100) % 90 == 0)
                    {
                        Debug.WriteLine($"killing {Thread.CurrentThread.Name}");
                        killThis = true;
                        mainWindow.Clients.Remove(id);
                    }
                }
            }
    
            public static void RunWork()
            {
                Console.WriteLine("RunWork");
                Random random = new Random();
                Int32 index = -1;
                while (!killAll)
                {
                    if (!mainWindow.Clients.Any())
                    {
                        killAll = true;
                        break;
                    }
                    Thread.Sleep(100);
                    index = random.Next(0, mainWindow.Clients.Count);                
                    var client = mainWindow.Clients[index];
                    Debug.WriteLine($"Changing {client.Name}");
                    client.State = RandomString(9);                 
                }
    
                Console.WriteLine("Worker killed");
            }
    
            private static void Main(string[] args)
            {
                Console.WriteLine("Starting. Enter id or kill");
    
                for (int i = 0; i < 100; i++)
                {
                    mainWindow.Clients.Add(i, new Client
                    {
                        Name = $"Client {i:000}",
                        State = "Unknown"
                    });
                }
    
                var worker = new Thread(RunWork);
                worker.Start();
    
                var threadList = new List<Thread>();
                threadList.Add(worker);
    
                for (int i = 0; i < 10; i++)
                {
                    var thread = new Thread(RunChild)
                    {
                        Name = $"Child {i:00}"
                    };
    
                    threadList.Add(thread);
                    thread.Start();
                }
    
                while (!killAll)
                {
                    var str = Console.ReadLine();
                    if (str.Equals("kill", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
    
                    int enteredId = -1;
    
                    if (int.TryParse(str, out enteredId))
                    {
                        id = enteredId;
                    }
                }
    
                foreach (var thread in threadList)
                {
                    thread.Join();
                }
    
                Console.WriteLine("all dead");
            }
        }
    }
