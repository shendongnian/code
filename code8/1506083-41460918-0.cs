    public class AnimalMap<T> : ClassMap<T>
        where T : Animal
    {
        public AnimalMap()
        {
            Table("MyAnimals");
            Id(x => x.ObjectId);
            Map(x => x.Data);
        }
    }
    
    public class CatMap : AnimalMap<Cat>
    {
        public CatMap()
        {
            Where("TypeId = 10");
        }
    }
