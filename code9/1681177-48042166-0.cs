    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore.Internal;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static partial class CustomExtensions
    	{
    		public static IQueryable Query(this DbContext context, string entityName) =>
    			context.Query(context.Model.FindEntityType(entityName).ClrType);
    
    		public static IQueryable Query(this DbContext context, Type entityType) =>
    			(IQueryable)((IDbSetCache)context).GetOrAddSet(context.GetDependencies().SetSource, entityType);
    	}
    }
