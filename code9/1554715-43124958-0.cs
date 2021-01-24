        public void Refresh(object entity)
        {
            DbEntityEntry entry = context.Entry(entity);
            entry.Reload();
            var values = entity.GetType().BaseType
                               .GetProperties()
                               .Where(propertyInfo => propertyInfo.GetCustomAttributes(typeof(ReloadCollectionOnRefresh), false).Count() > 0)
                               .Select(propertyInfo => propertyInfo.Name);
            
            foreach (string value in values)
            {
                var collection = entry.Collection(value);
                collection?.Load();
            }
        }
