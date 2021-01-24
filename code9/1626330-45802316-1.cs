    static void Main(string[] args)
    {
        var tasks = new[] {"test1", "test2"}.Select(SaveData);
        Task.WhenAll(tasks).Wait();
    }
    
    private static async Task SaveData(string fileName)
    {
        var filename = $"c:\\temp\\{fileName}.txt";
        var url = $"https://testapi?name eq '{fileName}') ";
        var client = new WebClient();
        client.OpenReadCompleted += (sender, e) =>
        {
            var reply = e.Result;
            StreamReader s;
            s = new StreamReader(reply);
            using (var reader = new JsonTextReader(s))
            {
                reader.SupportMultipleContent = true;
                var serializer = new JsonSerializer();
                var parsedData = serializer.Deserialize(reader).ToString();
                File.WriteAllText(filename, parsedData);
                Console.WriteLine($"Result save at {fileName}");
            }
        };
    
        await client.OpenReadTaskAsync(new Uri(url));
    }
