             List<Person> people = new List<Person>();
             for (int n = 0; n < 20; n++)
             {
                Console.WriteLine("Input name of  person no. {0}: ", n);
                name = Console.ReadLine();
                Console.WriteLine("Input surname of person no. {0}", n);
                surname = Console.ReadLine();
                Person newPerson = new Person(name, surname);
                people.Add(newPerson);
             }
