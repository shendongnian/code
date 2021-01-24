    namespace Our.DAL.Implementations
    {
       public class TpdEntities : DbAccess, IEntityAccess
       {
         // TEntityType shortened to TEntTyp 
         public IQueryable<TEntTyp> Query<TEntTyp>(Expression<Func<TEntTyp, bool>> query) 
         where TEntTyp: class
         {
           return Set<TEntTyp>().Where(query);
         }
       }
    }
