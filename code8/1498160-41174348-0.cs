    var jsonString = @"{
         ""Date"": ""2016-12-15"",
         ""Data"": {
           ""A"": 4.4023,
           ""AB"": 1.6403,
           ""ABC"": 2.3457
         }
    }";
    var root = new JavaScriptSerializer().Deserialize<object>(jsonString);
    var properties = root
        // Select nested Data object
        .JsonPropertyValue("Data")
        // Iterate through its children, return property names.
        .JsonPropertyNames()
        .ToArray();
    Console.WriteLine(String.Join(",", properties)); // Prints A,AB,ABC
