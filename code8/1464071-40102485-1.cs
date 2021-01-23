    public void RefreshPersons()
        {
            PersonList.Clear();
            foreach (string line in File.ReadLines(@"C:\Users\c.philipp\Downloads\adressbuch.csv", Encoding.GetEncoding("iso-8859-1")))
            {
                string[] substrings = line.Split(',');
                Person person = new Person
                {
                    Surname = substrings[0],
                    Name = substrings[1],
                    Street = substrings[2],
                    HouseNumber = substrings[3],
                    PostalCode = substrings[4],
                    City = substrings[5],
                    PhoneAreaCode = substrings[6],
                    PhoneNumber = substrings[7],
                    Email = substrings[8]
                };
                PersonList.Add(person);
            }
        }
