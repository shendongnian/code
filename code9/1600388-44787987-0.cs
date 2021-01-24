    StringBuilder sb = new StringBuilder();
    foreach (var element in collection)
    {
        sb.AppendLine(JsonConvert.SerializeObject(element, Formatting.None));
    }
    // use the NDJSON output
    Console.WriteLine(sb.ToString());
    
    
