    var lines = File.ReadAllLines(filepath);
    var persons = new List<Person>();
    
    foreach(var line in lines)
    {
        var values = line.Split(',');
        var name = values[0];
        var score = int.Parse(line[1].ToString());
    
        var person = persons.FirstOrDefault(x => x.Name == name);
        if(person == null)
        {
            var newPerson = new Person(name, score);
            persons.Add(newPerson);
        }
        else
        {
            person.Score += score;
        }
    }
