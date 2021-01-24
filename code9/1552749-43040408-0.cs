    public class Person
    {
        public string Sex { get; set; }
        public string Name { get; set; }
    }
    private static void LinQ3()
    {
        var namesList = new List<Person>();
        namesList.Add(new Person() { Sex = "M", Name = "Jonh" });
        namesList.Add(new Person() { Sex = "F", Name = string.Empty });
        namesList.Add(new Person() { Sex = "M", Name = string.Empty });
        var nullV = namesList.Select(x => new {
            Sex=x.Sex,
            nullableName= string.IsNullOrWhiteSpace(x.Name)?null: x.Name
        });
    }
