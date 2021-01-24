            var persons = hubProxy.Invoke<IEnumerable<Person>>("GetPersonsSynchronous", SearchCriteria, noteFields).Result;
            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.LastName}, {person.FirstName}");
            }
