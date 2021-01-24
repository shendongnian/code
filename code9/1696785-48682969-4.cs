    public DisplayFactory
    {
        public MyDbContext MyDbContext {get; set;}
        public Display<TProperty> Create<TEntity, TProperty>(int id,
           Expression<Func<TEntity, TProperty>> propertySelector,
           Action<TEntity, TProperty> propertyUpdater,
           Func<string, TProperty> parse,
           Func<TProperty, string> toDisplayValue)
        {
            return new Display<TProperty>()
            {
                Id = id,
                Parse = parse,
                ToDisplayValue = toDisplayValue,
                FetchValue = (id) => this.MyDbContext.DbSet<TEntity>()
                     .Where(entity => entity.Id == id) // this is where I need the interface
                     .Select(propertySelector)
                     .SingleOrDefault(),
                SetValue = (id, valueToUpdate) =>
                {
                     TEntity entityToUpdate = this.MyDbContext.DbSet<TEntity>()
                         .Where(entity => entity.Id == id)
                         .SingleOrDefault();
                     propertyUpdate(entityToUpdate, valueToUpdate);
                     SaveChanges(); 
                }
            }
        }
          
