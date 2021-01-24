    public interface IPerson 
    {
        public int Id {get;}
        public string Name {get;}
    }
    
    public GoodPerson : IPerson
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int GoodDeedCount {get; set;}
    
    
        void SayGoodDay(IPerson toPerson)
        {
            GoodDeedCount++;
            return $"Good day, {toPerson.Name}! :)"
        }
    }
    
    public BadPerson : IPerson
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Badness {get; set;}
    
        void SayShutUp(IPerson toPerson)
        {
            Badness++;
            return $"Shut up, {toPerson.Name}!"
        }
    }
    
    public UglyPerson : IPerson
    {
        public int Id {get; set;}
        public string Name {get; set;}
    
        void SayNothing() { }
    }
    
    public static List<T> BuildList<T>()
        where T: new()
    {
        var result = new List<T>();
        if (T is GoodPeson)
        {
             result.Add(new GoodPerson{Id = 1, Name = "Pinky", GoodDeedCount = 0});
             result.Add(new GoodPerson{Id = 2, Name = "Brain", GoodDeedCount = 0});
        }
        else if (T is BadPerson)
        {
             result.Add(new BadPerson{Id = 1, Name = "Sunshine", Badness = 0});
        }
        else if (T is UglyPerson)
        {
             result.Add(new UglyPerson{Id = 1, Name = "No", Badness = 0});
        }
        return result;
    }
