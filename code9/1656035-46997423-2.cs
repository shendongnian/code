    public class DataAccess : IDataAccess
    {
        public async Task InsertAsync<T>(T entity)
        {
            //... obtain an instance of IDataAccess<T>
            var enityHandler = GetEntityHandler<T>();
            return entityHandler.InsertAsync(entity);
        }
        private IDataAccess<T> GetEntityHandler<T>()
        {
            // you can use a DI container library like Autofac
            // or just implement your own simpliest service locator like this:
            return (IDataAccess<T>)_handlerByEntityType[typeof(T)];
        }
        // the following simplest service locator can be replaced with a 
        // full-blown DI container like Autofac
        private readonly IReadOnlyDictionary<Type, object> _handlerByEntityType = 
            new Dictionary<Type, object> {
                { typeof(Student), new StudentDataAccess() }, 
                { typeof(University), new UniversityDataAccess() }, 
                // ... the rest of your entities
            };
    }
