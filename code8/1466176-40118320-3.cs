        static void Main(string[] args)
        {
            using (var db = new CompanyContext())
            {
                // add a person
                var person = new Person() { Name = "Joe" };
                db.Persons.Add(person);
                // "make" him manager
                var manager = new Manager();
                manager.Persons.Add(person);
                db.Managers.Add(manager);
                db.SaveChanges();
            }
            Console.ReadKey();
        }
