    private static void Main()
    {
    	var defaultIndex = "employees";
    
    	var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    		.InferMappingFor<Employee>(i => i
    			.IndexName(defaultIndex)
    		)
    		.DefaultIndex(defaultIndex)
            // following settings are useful while developing
            // but probably don't want to use them in production
    		.DisableDirectStreaming()
    		.PrettyJson()
    		.OnRequestCompleted(callDetails =>
    		{
    			if (callDetails.RequestBodyInBytes != null)
    			{
    				Console.WriteLine(
    					$"{callDetails.HttpMethod} {callDetails.Uri} \n" +
    					$"{Encoding.UTF8.GetString(callDetails.RequestBodyInBytes)}");
    			}
    			else
    			{
    				Console.WriteLine($"{callDetails.HttpMethod} {callDetails.Uri}");
    			}
    
    			Console.WriteLine();
    
    			if (callDetails.ResponseBodyInBytes != null)
    			{
    				Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
    						 $"{Encoding.UTF8.GetString(callDetails.ResponseBodyInBytes)}\n" +
    						 $"{new string('-', 30)}\n");
    			}
    			else
    			{
    				Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
    						 $"{new string('-', 30)}\n");
    			}
    		});
    
    	var client = new ElasticClient(settings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    		
    	client.CreateIndex(defaultIndex, c => c
    		.Settings(s => s
    			.NumberOfShards(1)
    		)
    		.Mappings(m => m
    			.Map<Employee>(mm => mm
    				.AutoMap()
    			)
    		)
    	);
    
    	// Create 4 employees
    	var al = new Employee("Al", "Bundy", 1500);
    	var bud = new Employee("Bud", "Bundy", 975);
    	var marcy = new Employee("Marcy", "Darcy", 4500);
    	var jefferson = new Employee("Jefferson", "Darcy", 0);
    	
    	client.IndexMany(new [] { al, bud, marcy, jefferson });
    	
    	// refresh the index after indexing. We do this here for example purposes,
    	// but in a production system, it's preferable to use the refresh interval
    	// see https://www.elastic.co/blog/refreshing_news
    	client.Refresh(defaultIndex);
    
    	// query the index
    	var result = client.Search<Employee>(s => s
    		.Aggregations(a => a
    			.Terms("Families", ts => ts
    				.Field(o => o.Last_Name.Suffix("keyword")) // use the keyword sub-field for terms aggregation
    				.Size(10)
    				.Aggregations(aa => aa
    					.Sum("FamilySalary", sa => sa
    						.Field(o => o.Salary)
    					)
    				)
    			)
    		)
    	);
    
    	// Get the number of different families (Result should be 2: Bundy and Darcy)  
    	// and get the family-salary of family Bundy and the family-salary for the Darcys
    	var names = result.Aggs.Terms("Families");
    	
    	foreach(var name in names.Buckets)
    	{
    		var sum = name.Sum("FamilySalary");
    		Console.WriteLine($"* family {name.Key} earns {sum.Value}");
    	}
    }
    
    public class Employee
    {
    	public string First_Name { get; set; }
    	public string Last_Name { get; set; }
    	public int Salary { get; set; }
    
    	public Employee(string first_name, string last_name, int salary)
    	{
    		this.First_Name = first_name;
    		this.Last_Name = last_name;
    		this.Salary = salary;
    	}
    	public Employee() { }
    }
