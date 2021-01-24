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
