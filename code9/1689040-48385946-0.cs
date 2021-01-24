     public IEnumerable<string> GetReferencedEntities<TEntity>() where TEntity : class
        {
            using (var context = new DataContext())
            {
               
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();
                string tEntityName = typeof(TEntity).Name;
                var Fks = set.EntitySet.EntityContainer.AssociationSets.Where(r => r.Name.EndsWith(tEntityName)).ToList();
                //var Fks = set.EntitySet.ElementType.NavigationProperties.Select(n => n.DeclaringType);
                return Fks.Select(fk => fk.Name);
            }
        }
    var result = GetReferencedEntities<Country>();
