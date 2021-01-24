        public class Person
        {
            public string Sex { get; set; }
            public string name { get; set; }
        }
        private static void Linq2()
        {
            var namesList = new List<Person>();
            namesList.Add(new Person() { Sex = "M", name = "Jonh" });
            namesList.Add(new Person() { Sex = "M", name = "James" });
            namesList.Add(new Person() { Sex = "F", name = "Maria" });
            namesList.Add(new Person() { Sex = "F", name = "Cindy" });
            namesList.Add(new Person() { Sex = "M", name = "Jim" });
            namesList.Add(new Person() { Sex = "F", name = "Helen" });
            namesList.Add(new Person() { Sex = "M", name = "Jonh" });
            namesList.Add(new Person() { Sex = "F", name = "Maria" });
            namesList.Add(new Person() { Sex = "F", name = "Cindy" });
            namesList.Add(new Person() { Sex = "M", name = "Jonh" });
            var grouped = from personItem in namesList
                          group personItem by personItem.name into personGroup
                          select new
                          {
                              name = personGroup.Key,
                              count = personGroup.Count()
                          };
            // here you order your list Descending in order the name 
            // with the most Ocurrance will be on the top and select the First
            var nameMaxOcurrance = grouped.OrderByDescending(x => x.count).First().name;
            var maxOcurrance = grouped.Max(x => x.count);
            Console.WriteLine("Name with Max Ocurrances:" + nameMaxOcurrance);
            Console.WriteLine("Max Ocurrances:" + maxOcurrance);
        }
