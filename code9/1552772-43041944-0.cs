    var json = @"{
        ""Result"": [
        ""Done"",
        {
            ""StudentId"": 45,
            ""CourseId"": 27
        }
        ]
    }";
    var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
    foreach (var res in rootObject.Result)
        if (res is string)
            Console.WriteLine(rootObject.Result[0]);
        else
            try
            { 
                Console.WriteLine(res.StudentId);
            }
            catch
            {
                // Unexpected element type
            }
