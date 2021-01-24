    public void Add(T item)
    {
        var destinationType = _mappings[typeof(T)];
        var newEntity = _mapper.Map(item, typeof(T), destinationType);
        this.Entities.Add(newEntity);
        this.db.SaveChanges();
    }
    // Maybe injected through UnityConfig...
    private static _mappings = new Dicionary<Type, Type> {{ typeof(API.ArticleType), typeof(DAL.ArticleType) }};
 
