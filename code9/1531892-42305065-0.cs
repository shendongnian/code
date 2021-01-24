    public class People {
        public string Id {get;set;}
        public string Name {get;set;}
        public DateTime? Date {get;set;}
        public int? Age {get;set;}
    }
    public class SmallPeople {
    
        public string Id {get;set;}
        public string Name {get;set;}
        public People ToPeople()
        {
            var people = new People();
            people.Id = Id;
            people.Name = Name;
            people.Age = null;
            people.Date = null;
            return people;
        }
    }
    var small = new SmallPeople();
    small.Id="5";
    small.Name="My Name";
    var people = small.ToPeople();
