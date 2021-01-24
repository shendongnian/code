    public interfase IEntity
    {
       string Name {get;set;}
       string Surname {get;set;}
    }
    
    public class Repository<T> where T : class, IEntity
    {
        public IList<T> Get(KendoGridFilterSort.FilterContainer filter)
        {
            return _entities.Set<T>().Where(x => x.Name == filter.Name && x.Surname == filter.Surname).ToList();
        }
    }
