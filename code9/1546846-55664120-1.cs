    public class Main<T> : IMain<T> where T : class
        {
            public DataContext db;
            public void Add(T entity)
            {
                db.Set<T>().Add(entity);
            }
    
            public void Del(int id)
            {
                var q = GetById(id);
                db.Set<T>().Remove(q);
            }
    
            public void Edit(T entity)
            {
                db.Entry<T>(entity).State = EntityState.Modified;
            }
    
            public List<T> GetAll()
            {
                return db.Set<T>().Select(a=>a).ToList();
            }
    
            public T GetById(int id)
            {
                return db.Set<T>().Find(id);
            }
    
            public int Savechange()
            {
                return db.SaveChanges();
            }
        }
