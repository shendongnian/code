    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var defaultIndex = "projects";
        var connectionSettings = new ConnectionSettings(pool, new InMemoryConnection())
            .DefaultIndex(defaultIndex )
            .PrettyJson()
            .DisableDirectStreaming()
            .OnRequestCompleted(response =>
                {
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
    
        var availableToField = Infer.Field<Project>(f => f.Availablity.AvailableTo);
        var availableFromField = Infer.Field<Project>(f => f.Availablity.AvailableFrom);
        var nameField = Infer.Field<Project>(f => f.Contact.Name);
    
        var active_date_to = new DateRangeQuery
        {
            Name = "toDate",
            Boost = 1.1,
            Field = availableToField,
            GreaterThan = DateTime.Now,
            TimeZone = "+01:00",
            Format = "yyyy-MM-ddTHH:mm:SS||dd.MM.yyyy"
        };
        var active_date_from = new DateRangeQuery
        {
            Name = "from",
            Boost = 1.1,
            Field = availableFromField,
            LessThanOrEqualTo = DateTime.Now,
            TimeZone = "+01:00",
            Format = "yyyy-MM-ddTHH:mm:SS||dd.MM.yyyy"
        };
    
        var ret = client.Search<Project>(s => s
            .Query(q =>
                active_date_from &&
                active_date_to && q
                .Match(d => d
                    .Query("free text")
                )
            )
            .From(0)
            .Size(10)
        );
    }
    
    public class Project
    {
        public Availibility Availablity { get; set; }
        public Contact Contact { get; set; }
    }
    
    public class Contact
    {
        public string Name { get; set; }
    }
    
    public class Availibility
    {
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
    }
