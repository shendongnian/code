        [TestMethod]
        public void TestMethod1()
        {
            var PersonTable = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Test1"
                },
                new Person
                {
                    Id = 2,
                    Name = "Test2"
                },
            };
            var CarTable = new List<PersonCar>
            {
                new PersonCar
                {
                    Id = 1,
                    IdPerson = 2
                },
                new PersonCar
                {
                    Id = 2,
                    IdPerson = 3
                }
            };
            var result = (from person in PersonTable
                join cars in CarTable on person.Id equals cars.IdPerson into carsGroup
                         from args in carsGroup.DefaultIfEmpty()
                select new MyClass
                {
                    Person = person,
                    Cars = carsGroup.ToList()
                }).ToList();
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result.Count(res => res.Cars.Count == 0));
            Assert.AreEqual(1, result.Count(res => res.Cars.Count == 1));
        }
