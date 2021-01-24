    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp7
    {
        class Program
        {
            static void Process(int i, int j)
            {
                var client = new RestClient("http://127.0.0.1:5000/route/v1/table/");
    
                //request a server with spesific lats,longs
                var request = new RestRequest(String.Format("{0},{1};{2},{3}", le.LocationList[i].longitude, le.LocationList[i].latitude, le.LocationList[j].longitude, le.LocationList[j].latitude));
    
                //reading the response and deserialize into object
                var response = client.Execute<RootObject>(request);
    
                //defining objem with the List of attributes in routes
                var objem = response.Data.routes;
    
                //this part reading all distances and durations in each response and take them into dist and dur matrixes.
    
                // !!! 
                // !!! THIS LOOP NEEDS TO GO. 
                // !!! IT MAKES NO SENSE!
                // !!! YOU ARE OVERWRITING YOUR OWN DATA!
                // !!!
                Parallel.ForEach(objem, (o) =>
                {
                    dist[i, j] = o.distance;
                    dur[i, j] = o.duration;
                    threads[i, j] = Thread.CurrentThread.ManagedThreadId;
                    Thread.Sleep(10);
                });
            }
    
            static void Main(string[] args)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
    
                var rowCount = 2500;
                var maxThreads = 100;
    
                var allPairs = Enumerable.Range(0, rowCount).SelectMany(x => Enumerable.Range(0, rowCount).Select(y => new { X = x, Y = y }));
    
                Parallel.ForEach(allPairs, new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, pair => Process(pair.X, pair.Y));
                
                watch.Stop();
    
                var elapsedMs = watch.ElapsedMilliseconds;
            }
        }
    }
