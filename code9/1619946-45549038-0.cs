    public class EntityRepository<T,Y> : IRepository<T,Y>
              where T : Entity<Y>
              where Y : struct
        {
     public virtual async Task<T> GetByID(Y id, bool isDeleted=false)
            {
                var result = await con.Set<T>().FirstOrDefaultAsync(x=>(object)x.ID==(object)id);
                return result;
            } 
    
        }
