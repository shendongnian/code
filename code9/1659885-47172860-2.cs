            var list = new List<ContactTemp> {
                new ContactTemp { City = "1", State = "1" },
                new ContactTemp { City = "1", State = "2" },
                new ContactTemp { City = "2", State = "1" },
                new ContactTemp { City = "2", State = "2" }
            };
            foreach (var contact in RemoveDupliacacse(list, new List<Func<ContactTemp, object>> { (ContactTemp contact) => contact.State, (ContactTemp contact) => contact.City }))
            {
                Console.WriteLine($"City:{contact.City}, State:{contact.State}");
            }
            // This will output:
            // City: 1, State: 1
            // If you want to check duplication of the combination of the selected columns, 
            // you can do it like this;
            foreach (var contact in RemoveDupliacacse(list, new List<Func<ContactTemp, object>> { (ContactTemp contact) => new { contact.State, contact.City } }))
            {
                Console.WriteLine($"City:{contact.City}, State:{contact.State}");
            }
            // This will output:
            // City: 1, State: 1
            // City: 1, State: 2
            // City: 2, State: 1
            // City: 2, State: 2
