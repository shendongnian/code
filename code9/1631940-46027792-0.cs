    public static bool MyIsAutoIncrement<TEntity>(this DbContext pContext) where TEntity : class
        {
            var objectContext = ((IObjectContextAdapter)pContext).ObjectContext;
            var set = objectContext.CreateObjectSet<TEntity>();
            var myPkTypeKind = (PrimitiveTypeKind)set.EntitySet.ElementType.KeyMembers[0].GetPropValue("PrimitiveType").GetPropValue("PrimitiveTypeKind");
            switch (myPkTypeKind)
            {
                case PrimitiveTypeKind.Int16:
                    return true;
                case PrimitiveTypeKind.Int32:
                    return true;
                case PrimitiveTypeKind.Int64:
                    return true;
            }
            return false;
        }
