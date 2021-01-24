    class Example
    {
        static void Main()
        {
            var l = new[]
            {
                new Employee {Id = 1, Name = "1", Email = "1"},
                new Employee {Id = 2, Name = "2", Email = "2"}, 
                new Employee {Id = 2, Name = "3", Email = "3"}
            };
            var s = JsonConvert.SerializeObject(new { employees = l.ToDictionary(x => x.Name, x => x) });
        }
        
        class Employee
        {
            public int Id { get; set; }
            [JsonIgnore]
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
