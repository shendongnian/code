        public virtual void Update<TEntity>(IEnumerable<string> excludeColumnNames, params TEntity[] items)
        {
            foreach (var item in items)
            {
                _entities.Entry(item).State = EntityState.Modified;
                foreach (var cn in excludeColumnNames)
                {
                    _entities.Entry(item).Property(cn).IsModified = false;
                }
                
            }
            _entities.SaveChanges();
        }
