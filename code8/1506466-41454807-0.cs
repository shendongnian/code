    var json = @"""{\""value\"":[\""18\""]}""";
    Console.WriteLine("JSON: ");
    Console.WriteLine(json); // Prints "{\"value\":[\"18\"]}"
    var intermediateJson = JsonConvert.DeserializeObject<string>(json);
    var root = JsonConvert.DeserializeObject<RootObject>(intermediateJson);
    Console.WriteLine("Reserialized root: ");
    Console.WriteLine(JsonConvert.SerializeObject(root)); // Prints {"value":["18"]}
    Console.WriteLine("value:");
    Console.WriteLine(root.value.First()); // Prints 18
