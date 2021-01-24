    void Main()
    {   
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var connectionSettings = new ConnectionSettings(pool);
    
        var client = new ElasticClient(connectionSettings);
        var indexName = "bulk-index";
        
        if (client.IndexExists(indexName).Exists)
            client.DeleteIndex(indexName);
    
        client.CreateIndex(indexName, c => c
            .Settings(s => s
                .NumberOfShards(3)
                .NumberOfReplicas(0)
            )
            .Mappings(m => m
                .Map<DeviceStatus>(p => p.AutoMap())
            )
        );
    	
    	var size = 500;
    
        // set up the observable
        var bulkAllObservable = client.BulkAll(GetDeviceStatus(), b => b
            .Index(indexName)
            .MaxDegreeOfParallelism(4)
            .RefreshOnCompleted()
            .Size(size)
        );
    	
    	var countdownEvent = new CountdownEvent(1);
    	
        // set up an observer. Delegates passed are:
        // 1. onNext
        // 2. onError
        // 3. onCompleted
    	var bulkAllObserver = new BulkAllObserver(
    		response => Console.WriteLine($"Indexed {response.Page * size} with {response.Retries} retries"),
    		exception => 
    		{
    			countdownEvent.Signal();
    			throw exception;
    		},
    		() => 
            {
                Console.WriteLine("Finished");
                countdownEvent.Signal();
            });
  
        // subscribe to the observable  		
    	bulkAllObservable.Subscribe(bulkAllObserver);
    
        // wait indefinitely for it to finish. May want to put a
        // max timeout on this	
    	countdownEvent.Wait();
    }
    
    // lazily enumerated collection
    private static IEnumerable<DeviceStatus> GetDeviceStatus()
    {
        for (var i = 0; i < DocumentCount; i++)
            yield return new DeviceStatus(i); 
    }
    
    private const int DocumentCount = 20000;
    
    public class DeviceStatus
    {
        public DeviceStatus(int id) => Id = id;
        public int Id {get;set;}
    }
