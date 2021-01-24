    public static void Sync<TEntity, TEntityKey, TDTO>(this ICollection<TEntity> entityCollection, ICollection<TDTO> dtoCollection,
        Func<TEntity> entityConstructor, Action<TDTO, TEntity> copyAction,
        Action<TEntity> onDeleteAction,
        Func<TEntity, TEntityKey> entityKeySelector, 
        Func<TDTO, TEntityKey> dtoKeySelector)
        where TEntity : class
        where TEntityKey : struct
    {
        dtoCollection = dtoCollection ?? new TDTO[] { };
        except = except ?? new TEntityKey[] { };
        var dtoIds = dtoCollection.Select(dto => dtoKeySelector(dto)).Concat(except).ToSet();
        foreach (var entity in entityCollection.Where(x => false == dtoIds.Contains(entityKeySelector(x))).ToArray())
        {
            onDeleteAction(entity);
            entityCollection.Remove(entity);
        }
        var entityCollectionMap = entityCollection.ToDictionary(x => entityKeySelector(x));
        foreach (var dtoItem in dtoCollection)
        {
            TEntity entity = null;
            if (dtoKeySelector(dtoItem).HasValue)
            {
                entity = entityCollectionMap.GetDefault(dtoKeySelector(dtoItem), () => null);
            }
                
            if (null == entity)
            {
                entity = entityConstructor();
                entityCollection.Add(entity);
            }
            copyAction(dtoItem, entity);
        }
    }
