    enum Gender
    {
         Male,
         Female
    }
    class PersonStats
    {
        int Age;
        int Height;
        Gender Gender;
    }
    //Add to the dictionary
    var dict = Dictionary<string, PersonStats>();
    dict.Add("FrankerZ", new PersonStats{
       Age = 28,
       Height = 180,
       Gender = Gender.Male
    });
    //Some example filters:
    dict.Count(person => person.Age == 28); //1
    dict.Count(person => person.Gender == Gender.Male); //1
