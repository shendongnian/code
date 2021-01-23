    public class Person {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
    
    IEnumerable<int> personIds = persons
        .Select(p => new { Id = p.Id, FullName = p.FirstName + " " + p.LastName})
        .Where(a => a.FullName == "John Smith")
        .Select(a => a.Id);
