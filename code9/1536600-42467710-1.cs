    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Storage;
    public class DbColumnInfo
    {
    	public string Name;
    	public string Type;
    }
    
    public static class RelationalDbHelpers
    {
    	public static IEnumerable<DbColumnInfo> GetDbColums(this DbContext dbContext, Type clrEntityType)
    	{
    		var dbServices = dbContext.GetService<IDbContextServices>();
    		var relationalDbServices = dbServices.DatabaseProviderServices as IRelationalDatabaseProviderServices;
    		var annotationProvider = relationalDbServices.AnnotationProvider;
    		var typeMapper = relationalDbServices.TypeMapper;
    
    		var entityType = dbContext.Model.FindEntityType(clrEntityType);
    
    		// Not needed here, just an example 
    		var tableMap = annotationProvider.For(entityType);
    		var tableName = tableMap.TableName;
    		var tableSchema = tableMap.Schema;
    
    		return from property in entityType.GetProperties()
    			   let columnMap = annotationProvider.For(property)
    			   let columnTypeMap = typeMapper.FindMapping(property)
    			   select new DbColumnInfo
    			   {
    				   Name = columnMap.ColumnName,
    				   Type = columnTypeMap.StoreType
    			   };
    	}
    }
