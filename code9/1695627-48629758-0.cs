       public interface IHasKeyProperty<TId>
            {
                TId Key { get; set; }
            }
    
            public class Manager : IHasKeyProperty<int>
            {
                public int Key { get; set; }
    
                // Rest of manager code...
            }
    
            public class Employee : IHasKeyProperty<Guid>
            {
                public Guid Key { get; set; }
    
                // Rest of employee code...
            }
    
            public TEntity GetByKey<TEntity, TId>(TId key) where TEntity : IHasKeyProperty<TId>
            {
                return this._dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == key);
            }
