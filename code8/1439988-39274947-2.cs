    static void Main(string[] args)
    {
        IUnityContainer container = new UnityContainer();
        container.RegisterInstance<IAgeCalculator>("Years", new AgeInYearsCalculator());
        container.RegisterInstance<IAgeCalculator>("Days", new AgeInDaysCalculator());
        container.RegisterType<IPerson, Person>();
    
        var person1 = Factory<IPerson>.Create(container);
        person1.Name = "Jacob";
        person1.Gender = "Male";
        person1.Birthday = new DateTime(1995, 4, 1);
    
        var person2 = Factory<IPerson>.Create(container);
        person2.Name = "Emily";
        person2.Gender = "Female";
        person2.Birthday = new DateTime(1998, 10, 31);
    }
