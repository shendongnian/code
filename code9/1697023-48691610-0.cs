    //POCO
    public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        //Dummy repo for example
        public static class _personRepository
        {
            public static List<Person> GetAllPeople()
            {
                return new List<Person>();
            }
        }
    
        class Program
        {   
            //static helper class - accepts a POCO and dynamically adds a property and spits out a JObject
            private static JObject IDPerson(Person person)
            {
                var ret = JObject.FromObject(person);
                ret.Add("UID", Guid.NewGuid().ToString());
                return ret;
            }
            static void Main(string[] args)
            {
                //get the list of people
    
                var allpeople = _personRepository.GetAllPeople();
                //in line here select a new object from our helper method
                var qry =
                    (
                        from person
                        in allpeople
                        select IDPerson(person) //this is the dynamic bit 
                    ).ToList();
            }
        }
