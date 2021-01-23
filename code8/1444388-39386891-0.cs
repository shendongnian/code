     class Program
            {
                static void Main(string[] args)
                {
                    DoStuff().Wait();//As you can see my main thread is blocked if wait is used;
                    Console.WriteLine("Done");
                    Console.ReadLine();
                }
        
        
                public static async Task DoStuff() 
                {
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    var clientsTask = GetFromDBAsync(); //DON'T await
                    var balancesTask = GetBalancesAsync(); //DON'T await
                    await Task.WhenAll(clientsTask, balancesTask);//If the implementation is async dose a parallel call the nameing convention is async methods have Async at the end MethodAsync
        
                    var clients = clientsTask.Result;
                    var balances = balancesTask.Result;
        
                    var users = Enumerable.Range(clients, balances).Select(i=>new { IdNumber = i }); // I am mocking your query so you can see what is happening
        
                    var usersTasks = users.Select(user => GetClientAsync(user.IdNumber)).ToArray();
        
                    var userServerData = await Task.WhenAll(usersTasks);//You can do Task.WaitAll(usersTasks) if your method can't be async but this will block you main thread and can be buggy ;
        
                    foreach (var user in userServerData)
                    {
                        Console.WriteLine(user);
                    }
                    sw.Stop();
        
                    Console.WriteLine("Total time {0}", sw.ElapsedMilliseconds);//Total time is close to 2s rather then 22s if everething is sync;
                }
        
                public static Task<int> GetFromDBAsync()
                {
                    return Task.Delay(1000).ContinueWith(t => 0);
                }
        
                public static Task<int> GetBalancesAsync()
                {
                    return Task.Delay(1000).ContinueWith(t => 20);
                }
        
                public static Task<int> GetClientAsync(int clientId) 
                {
                    return Task.Delay(1000).ContinueWith(t => clientId);
                }
            }
