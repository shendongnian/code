    public class CalledClass<TEntity>
        where TEntity : IEntity
    {
        public List<TEntity> CalledMethod()
        {
             // You can access Name and Id here
             foreach(var entity in entities) // i know the code is not useful ;) 
                 entity.Id = "Unique ID";    // only for demonstration purposes
                 entity.Name = "Random Name";
             }
             return entities.ToList();
        }
    }
