     public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            public void Copy(Person person)
            {
                this.FirstName = person.FirstName;
                this.LastName = person.LastName;
            }
        }
