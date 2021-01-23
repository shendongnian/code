    namespace DataAccessLayer.DataAccessObject
    {
        public interface IGenericHistoryRepository<T> where T : class
        {
            
            void Add(params T[] items);
            void AddList(params T[] items);
            void Update(params T[] items);
            void Remove(params T[] items);
    
        }
        public class GenericHistoryRepository<T> : IGenericHistoryRepository<T> where T : class
        {
            
            public virtual void Add(params T[] items)
            {
                using (var context = new MainContext())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    context.SaveChanges();
                }
            }
            public void AddList(params T[] items)
            {
                using (var context = new MainContext())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    context.SaveChanges();
                }
            }
            public virtual void Update(params T[] items)
            {
                using (var context = new MainContext())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                   
                    context.SaveChanges();
                  
                }
            }
            public virtual void Remove(params T[] items)
            {
                using (var context = new MainContext())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    context.SaveChanges();
                }
            }
            
        }
    
     }
