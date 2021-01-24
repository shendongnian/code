    public class TheRepository<T> : IRepository<T> where T : class, IHaveId
    {
        public void InsertOrUpdate(T instance)
        {
            if (instance.Id == default(int))
            {
                context.Set<T>().Add(instance);
            }
        }
    }
