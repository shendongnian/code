    private List<DbPerson> GenerateTestDb()
    {
        var result = new List<DbPerson>
        {
            new DbPerson { Id = 1,FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1963, 6, 14), Age = 53 },
            new DbPerson { Id = 2,FirstName = "Jane", LastName = "Hunt", BirthDate = new DateTime(1972, 1, 16), Age = 44 },
            new DbPerson { Id = 3,FirstName = "Aaron", LastName = "Pitch", BirthDate = new DateTime(1966, 7, 31), Age = 50 },
        };
        return result;
    }
