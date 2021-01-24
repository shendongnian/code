        public interface IBaseRepository<T> where T : class
            {
                IQueryable<T> GetAll();
                IQueryable<T> FindByFunc(Expression<Func<T, bool>> predicate);
                void AddEntity(T entity);
                void DeleteEntity(T entity);
                void EditEntity(T entity);
                void SaveEntity();
            }
    
        public class BaseRepository<context, T> : IBaseRepository<T> where T : class where context : DbContext, new()
            {
                private context _entities = new context();
                public context Context
                {
        
                    get { return _entities; }
                    set { _entities = value; }
                }
        
                public virtual IQueryable<T> GetAll()
                {
        
                    IQueryable<T> query = _entities.Set<T>();
                    return query;
                }
        }
    
    private static IUnityContainer BuildUnityContainer()
            {
                var container = new UnityContainer();
                GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
                BusinessComponent(container);
                DataBaseComponent(container);
                container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<,>));
    
    
                return container;
            }
