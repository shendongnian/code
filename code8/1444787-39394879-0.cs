    public class Person
    {
        public string idvalue { get; set; }
        public string DName { get; set; }
        public string FName { get; set; }
    }
    List<Person> persons = new List<Person>();
    persons.Add(new Person { DName = "A" });
    persons.Add(new Person { DName = "B" });
    persons.Add(new Person { DName = "C" });
    persons.Add(new Person { DName = "D" });
    var result = persons.Where(p => p.DName == "D");
    result.Dump();
