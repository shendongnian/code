    var firstWorker = workerList.First();
    var keys = firstWorker.customerField.Keys.ToList();
    
    var headers = new []{ "name", "phone", "age"}.Concat(keys).ToList();
    var csv = new CsvWriter( textWriter );
    
    // Write the headers
    foreach( var header in headers )
    {
        csv.WriteField(header);
    }
    csv.NextRecord();
    
    // Write the rows
    foreach( var item in workerList)
    {
        csv.WriteField(item.name);
        csv.WriteField(item.phone);
        csv.WriteField(item.age);
        var dict = worker.customerField;
        foreach (var key in keys)
        {
            csv.WriteField(dict[key]);
        }
        csv.NextRecord();
    }
