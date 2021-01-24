    static void Main(string[] args)
    {
        string input = @"{""Job #"": ""1"", ""Job Type"": ""A""}";
        var job1 = JsonConvert.DeserializeObject<Job1>(input, new JsonSerializerSettings
        {
            ContractResolver = new JobContractResolver()
        });
        Console.WriteLine("JobType: {0}", job1.JobType);
        Console.WriteLine("JobNumber: {0}", job1.JobNumber);
    }
