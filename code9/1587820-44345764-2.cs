    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
    	var connectionSettings = new ConnectionSettings(pool)
            .InferMappingFor<Person>(m => m
                .IndexName("people")
            )
    		.PrettyJson()
    		.DisableDirectStreaming()
    		.OnRequestCompleted(response =>
    			{
    				// log out the request
    				if (response.RequestBodyInBytes != null)
    				{
    					Console.WriteLine(
    						$"{response.HttpMethod} {response.Uri} \n" +
    						$"{Encoding.UTF8.GetString(response.RequestBodyInBytes)}");
    				}
    				else
    				{
    					Console.WriteLine($"{response.HttpMethod} {response.Uri}");
    				}
    
    				Console.WriteLine();
    
    				// log out the response
    				if (response.ResponseBodyInBytes != null)
    				{
    					Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
    							 $"{Encoding.UTF8.GetString(response.ResponseBodyInBytes)}\n" +
    							 $"{new string('-', 30)}\n");
    				}
    				else
    				{
    					Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
    							 $"{new string('-', 30)}\n");
    				}
    			});
    
    	var client = new ElasticClient(connectionSettings);
    
        if (client.IndexExists("people").Exists)
        {
            client.DeleteIndex("people");
        }
        
        client.CreateIndex("people", c => c
            .Mappings(m => m
                .Map<Person>(mm => mm
                    .AutoMap()
                    .Properties(p => p
                        .Nested<Position>(n => n
                            .Name(nn => nn.Positions)
                            .AutoMap()
                        )
                    )
                )
            )
        );
    
        client.IndexMany(new[] {
            new Person
            {
                FullName = "Person 1",
                TotalSalary = 100000,
                Positions = new List<Position>
                {
                    new Position
                    {
                        Name = "Janitor",
                        AverageMonthLimit = 5,
                        MonthsWorked = 3,
                        HasAverageLimitStatistic = true
                    }
                }
            },
            new Person
            {
                FullName = "Person 2",
                TotalSalary = 150000,
                Positions = new List<Position>
                {
                    new Position
                    {
                        Name = "Coach",
                        AverageMonthLimit = 5,
                        HasAverageLimitStatistic = true
                    }
                }
            },
            new Person
            {
                FullName = "Person 3",
                TotalSalary = 200000,
                Positions = new List<Position>
                {
                    new Position
                    {
                        Name = "Teacher",
                        HasAverageLimitStatistic = false,
                        ExpirationDate = DateTime.Now.AddMonths(6)
                    }
                }
            },              
            new Person
            {
                FullName = "Person 4",
                TotalSalary = 250000,
                Positions = new List<Position>
                {
                    new Position
                    {
                        Name = "Head",
                        HasAverageLimitStatistic = false,
                        ExpirationDate = DateTime.Now.AddYears(2)
                    }
                }
            }
        });
        
        
        client.Refresh(IndexName.From<Person>());
    
        var searchResponse = client.Search<Person>(s => s
            .Query(q => q
                .Nested(n => n
                    .Path(p => p.Positions)
                    .Query(nq => (+nq
                        .Term(f => f.Positions.First().HasAverageLimitStatistic, true) && +nq
                        .Script(sq => sq
                            .Inline("doc['positions.monthsWorked'].value != 0 && doc['positions.averageMonthLimit'].value > doc['positions.monthsWorked'].value")
                        ) && +nq
                        .Script(sq => sq
                            .Inline("doc['positions.monthsWorked'].value != 0 && (doc['positions.averageMonthLimit'].value - 12) < doc['positions.monthsWorked'].value")
                        )) || (+nq 
                        .Term(f => f.Positions.First().HasAverageLimitStatistic, false) && +nq
                        .DateRange(d => d
                            .Field(f => f.Positions.First().ExpirationDate)
                            .GreaterThan(DateTime.Now.Date)
                            .LessThan(DateTime.Now.Date.AddYears(1))
                        ))
                    )
                )
            )
        );
    
    }
    
    public class Person
    {
        public string FullName { get; set; }
        public decimal TotalSalary { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
    }
    
    public class Position
    {
        public string Name { get; set; }
        public bool IsCurrentPosition { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? MonthsWorked { get; set; }
        public bool HasAverageLimitStatistic { get; set; } = false;
        public int AverageMonthLimit { get; set; } = 0;
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
    }
