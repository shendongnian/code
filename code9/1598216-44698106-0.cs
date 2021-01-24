    var typedJson = @"{""$type"":""ConsoleApp2.Program+TestData, ConsoleApp2"",""TestField"":0}";
    var testData = JsonConvert.DeserializeObject(typedJson, new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Objects
    });
    var json = JsonConvert.SerializeObject(testData);    // <----- Notice no settings here
    Console.WriteLine(json);
    // Outputs:
    //     {"TestField":0}
