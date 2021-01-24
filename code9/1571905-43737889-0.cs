    var rawjson = "[{'PersonName': 'Jim Test'}]";
    
    string[] separatingChars = { "[", ",", "]" };  // split on these chars
    string[] docs = rawjson.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries );  
            
    foreach (string doc in docs) {
        Console.WriteLine(BsonDocument.Parse(doc));
    }
