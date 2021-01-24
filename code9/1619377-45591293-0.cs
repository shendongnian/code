    public class RemoveEntityAndAllRelations
    {
        private DbContext _context;
        public void SetContext(DbContext ctx)
        {
            _context = ctx;
        }
        public void RemoveChildren(object parent)
        {
            Type obj = parent.GetType();
    
            MethodInfo method = typeof(RemoveUserAndAllRelations).GetMethod("GetICollections");
            MethodInfo generic = method.MakeGenericMethod(obj);
    
            var properties = (PropertyInfo[])generic.Invoke(this, null);
            if (properties.Any())
            {
                foreach (PropertyInfo propertyInfo in properties)
                {
                    object child = propertyInfo.GetValue(parent, null);
                    RemoveChildren(child);
                }
    
                try
                {
                    dynamic dd = parent;
                    _context.Entry(dd[0]).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                      //do what you like
                }
            }
            else
            {
                try
                {
                    dynamic dd = parent;
                    _context.Entry(dd[0]).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                      //do what you like
                }
            }
        }
        public PropertyInfo[] GetICollections<TEntity>() where TEntity : class
        {
            return typeof(TEntity).GetProperties().Where(m =>
                m.PropertyType.IsGenericType &&
                m.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
            ).ToArray();
        }
    }
