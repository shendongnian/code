    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public override bool Equals(object obj)
        {
             var person = obj as Person;
             if (person == null) return false;
             return person.Id == Id && person.Name = Name && //etc.
        }
    }
