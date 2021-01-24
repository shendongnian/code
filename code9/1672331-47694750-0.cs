    var x = new 
    {
        FirstName = String.Empty,
        LastName = String.Empty
    };
    var persons = new List<Person>(sqlResultData.Length);
    foreach (var record in sqlResultData)
    {
        x.FirstName = record[0];
        x.LastName = record[1];
        var s = JsonConvert.SerializeObject(x)`
        var personX = JsonConvert.Deserialize<Person>(s);
        persons.Add(person);
    }
