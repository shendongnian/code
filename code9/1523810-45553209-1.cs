        public static async Task RunChaos()
        {
            var clusterConnectionString = "localhost:19000";
            using (var client = new FabricClient(clusterConnectionString))
            {
                var startTimeUtc = DateTime.UtcNow;
                var stabilizationTimeout = TimeSpan.FromSeconds(30.0);
                var timeToRun = TimeSpan.FromMinutes(60.0);
                var maxConcurrentFaults = 7;
                var timeBetweenFaults = new TimeSpan(0, 0, 10);
                var timeBetweenIterations = new TimeSpan(0, 0, 10);
                Dictionary<string, string> _context = new Dictionary<string, string>();
                //Aggressive chaos...
                var clusterHealthPolicy = new System.Fabric.Health.ClusterHealthPolicy()
                {
                    MaxPercentUnhealthyApplications = 90,
                    MaxPercentUnhealthyNodes = 100
                };
                var parameters = new ChaosParameters(
                    stabilizationTimeout,
                    maxConcurrentFaults,
                    true, /* EnableMoveReplicaFault */
                    timeToRun,
                    _context,
                    timeBetweenIterations,
                    timeBetweenFaults,
                    clusterHealthPolicy);
                var token = new System.Threading.CancellationToken();
                try
                {
                    await client.TestManager.StartChaosAsync(parameters, new TimeSpan(0, 30, 0), token); 
                }
                catch (FabricChaosAlreadyRunningException)
                {
                    Console.WriteLine("An instance of Chaos is already running in the cluster.");
                }
                var filter = new ChaosReportFilter(startTimeUtc, DateTime.MaxValue);
                var eventSet = new HashSet<ChaosEvent>(new ChaosEventComparer());
                while (true)
                {
                    var report = await client.TestManager.GetChaosReportAsync(filter);
                    foreach (var chaosEvent in report.History)
                    {
                        if (eventSet.Add(chaosEvent))
                        {
                            Console.WriteLine(chaosEvent);
                        }
                    }
                    // When Chaos stops, a StoppedEvent is created.
                    // If a StoppedEvent is found, exit the loop.
                    var lastEvent = report.History.LastOrDefault();
                    if (lastEvent is StoppedEvent)
                    {
                        break;
                    }
                    Task.Delay(TimeSpan.FromSeconds(1.0)).GetAwaiter().GetResult();
                }
            }
        }
