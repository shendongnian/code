    public virtual async Task<TEntity> GetByIdAsync(object[] keyValues,
            List<Expression<Func<TEntity, object>>> includes,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Task<TEntity> model = null;
            foreach (var include in includes)
            {
                if (include.Body.Type.GetInterface(nameof(IEnumerable<TEntity>)) != null)
                { //this part generates SQL Below
                    await DbSet.Include(include).LoadAsync(cancellationToken);
                    model = DbSet.FindAsync(keyValues, cancellationToken);
                }
                else //this part is working
                {
                    var propertyName = ((MemberExpression)include.Body).Member.Name;
                    model = DbSet.FindAsync(keyValues, cancellationToken);
                    await DbContext.Entry(model.Result).Navigation(propertyName).LoadAsync(cancellationToken);
                }
            }
            
            if (model == null)
                model = DbSet.FindAsync(keyValues, cancellationToken);
            return await model;
        }
