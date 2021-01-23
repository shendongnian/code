    var jsonString = @"{
         ""Date"": ""2016-12-15"",
         ""Data"": {
           ""A"": 4.4023,
           ""AB"": 1.6403,
           ""ABC"": 2.3457
         }
    }";
    var root = JToken.Parse(jsonString);
    var properties = root
        // Select nested Data object
        .SelectTokens("Data")
        // Iterate through its children, return property names.
        .SelectMany(t => t.Children().OfType<JProperty>().Select(p => p.Name))
        .ToArray();
    Console.WriteLine(String.Join(",", properties)); // Prints A,AB,ABC
