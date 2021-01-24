        public class Person
        {
            public int PhoneNumber { get; set; }
            public string Name { get; set; }
            private List<Person> GetResult(Func<Person, object> p, string v)
            {
                List<Person> data = GetResultsFromDb();
                return data.Where(x => x.Name == v).ToList();
            }
            private List<Person> GetResultsFromDb()
            {
                return new List<Person>() {
                    new Person() { Name = "Mike"},
                    new Person() { Name = "John"},
                    new Person() { Name = "Mike"}
                };
            }
        }
