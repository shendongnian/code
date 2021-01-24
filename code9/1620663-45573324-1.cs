    static void Main(string[] args)
        {
            Person testObj = new Person
            {
                Id = Guid.NewGuid(),
                Name = "M.A",
                MyAddress = new Address
                {
                    AddressId = 1,
                    Country = "Egypt"
                }
            };
            var json = JsonConvert.SerializeObject(testObj, new MyJsonConverter());
            Console.WriteLine(json);
        }
