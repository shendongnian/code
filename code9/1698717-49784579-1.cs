    string lowerLimit = XmlConvert.ToString(DateTime.UtcNow.AddDays(-2), XmlDateTimeSerializationMode.RoundtripKind);
    // the format is Field + Operator + DateTime as constant + the UTC formated date enclosed single quotes
    var filterCondition = @"StartDate ge Datetime'"+lowerLimit+"'";
    
    var query = new TableQuery<JarvisEntity>().Where(filterCondition);
    
    foreach (var entity in table.ExecuteQuery(query))
    {
         //..... your work
    }
