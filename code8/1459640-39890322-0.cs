    static void Main(string[] args)
            {
                string[] inputs = new string[] { "ADD Mary Jane Watson ID 123456 AS Advanced", "ADD Mary Jane Jennifer Watson ID 123456 AS Advanced" };
    
                foreach (string input in inputs)
                {
                    Console.WriteLine(Extract(input).ToString());
                }
            }
    
            private static Person Extract(string input)
            {
                var s = input.Split(' ');
    
                var indexID = Array.FindIndex(s, a => a == "ID");
    
                string firstName = String.Join(" ", s.Skip(1).Take(indexID - 2));
                string lastName = s[indexID - 1];
                string idNumber = s[indexID + 1];
                string asLevel = s[s.Length - 1];
    
                return new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    IDNumber = idNumber,
                    ASLevel = asLevel
                };
            }
    
    
        }
    
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string IDNumber { get; set; }
            public string ASLevel { get; set; }
    
            public override string ToString()
            {
                return FirstName + " " + LastName + " " + IDNumber + " " + ASLevel;
            }
        }
