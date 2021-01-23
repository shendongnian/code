    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    var query = @"select 1 as 'Id', 'Foo' as 'Name' union all select 1 as 'Id', 'Bar' as 'Name'";
    var result = _connection.Query<Person>(query);
    
    foreach (var person in result)
    {
    	var output = string.Format("Id: {0}, Name: {1}", person.Id, person.Name);
    }
