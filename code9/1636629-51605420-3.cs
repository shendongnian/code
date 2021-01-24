        public void Detach(TEntity entity)
        {
            foreach (var entry in _ctx.Entry(entity).Navigations)
            {
                if (entry.CurrentValue is IEnumerable<IEntity> children)
                {
                    foreach (var child in children)
                    {
                        _ctx.Entry(child).State = EntityState.Detached;
                    }
                }
                else if (entry.CurrentValue is IEntity child)
                {
                    _ctx.Entry(child).State = EntityState.Detached;
                }
            }
            _ctx.Entry(entity).State = EntityState.Detached;
        }
