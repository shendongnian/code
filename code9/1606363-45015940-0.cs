    public int ExecuteInsertCommand(object entityObject)
    {
        DbCommand command = GenerateInsertCommand(entityObject);
        ConnectionState oldConnectionState = command.Connection.State;
        try
        {
            if (oldConnectionState != ConnectionState.Open)
                command.Connection.Open();
            int result = command.ExecuteNonQuery();
            return result;
        }
        finally
        {
            if (oldConnectionState != ConnectionState.Open)
                command.Connection.Close();
        }
    }
    public DbCommand GenerateInsertCommand(object entityObject)
    {
        ObjectContext objectContext = ((IObjectContextAdapter)Context).ObjectContext;
        var metadataWorkspace = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace();
        IEnumerable<EntitySetMapping> entitySetMappingCollection = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings;
        IEnumerable<AssociationSetMapping> associationSetMappingCollection = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().AssociationSetMappings;
        var entitySetMappings = entitySetMappingCollection.First(o => o.EntityTypeMappings.Select(e => e.EntityType.Name).Contains(entityObject.GetType().Name));
        var entityTypeMapping = entitySetMappings.EntityTypeMappings[0];
        string tableName = entityTypeMapping.EntitySetMapping.EntitySet.Name;
        MappingFragment mappingFragment = entityTypeMapping.Fragments[0];
        string sqlColumns = string.Empty;
        string sqlValues = string.Empty;
        int paramCount = 0;
        DbCommand command = Context.Database.Connection.CreateCommand();
        foreach (PropertyMapping propertyMapping in mappingFragment.PropertyMappings)
        {
            if (((ScalarPropertyMapping)propertyMapping).Column.StoreGeneratedPattern != StoreGeneratedPattern.None)
                continue;
            string columnName = ((ScalarPropertyMapping)propertyMapping).Column.Name;
            object columnValue = entityObject.GetType().GetProperty(propertyMapping.Property.Name).GetValue(entityObject, null);
            string paramName = string.Format("@p{0}", paramCount);
            if (paramCount != 0)
            {
                sqlColumns += ",";
                sqlValues += ",";
            }
            sqlColumns += SqlQuote(columnName);
            sqlValues += paramName;
            DbParameter parameter = command.CreateParameter();
            parameter.Value = columnValue;
            parameter.ParameterName = paramName;
            command.Parameters.Add(parameter);
            paramCount++;
        }
        foreach (var navigationProperty in entityTypeMapping.EntityType.NavigationProperties)
        {
            PropertyInfo propertyInfo = entityObject.GetType().GetProperty(navigationProperty.Name);
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                continue;
            AssociationSetMapping associationSetMapping = associationSetMappingCollection.First(a => a.AssociationSet.ElementType.FullName == navigationProperty.RelationshipType.FullName);
            EndPropertyMapping propertyMappings = associationSetMapping.AssociationTypeMapping.MappingFragment.PropertyMappings.Cast<EndPropertyMapping>().First(p => p.AssociationEnd.Name.EndsWith("_Target"));
            object relatedObject = propertyInfo.GetValue(entityObject, null);
            foreach (ScalarPropertyMapping propertyMapping in propertyMappings.PropertyMappings)
            {
                string columnName = propertyMapping.Column.Name;
                string paramName = string.Format("@p{0}", paramCount);
                object columnValue = relatedObject == null ?
                    null :
                    relatedObject.GetType().GetProperty(propertyMapping.Property.Name).GetValue(relatedObject, null);
                if (paramCount != 0)
                {
                    sqlColumns += ",";
                    sqlValues += ",";
                }
                sqlColumns += SqlQuote(columnName);
                sqlValues += string.Format("@p{0}", paramCount);
                DbParameter parameter = command.CreateParameter();
                parameter.Value = columnValue;
                parameter.ParameterName = paramName;
                command.Parameters.Add(parameter);
                paramCount++;
            }
        }
        string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, sqlColumns, sqlValues);
        command.CommandText = sql;
        foreach (DbParameter parameter in command.Parameters)
        {
            if (parameter.Value == null)
                parameter.Value = DBNull.Value;
        }
        return command;
    }
    public int ExecuteUpdateCommand(object entityObject)
    {
        DbCommand command = GenerateUpdateCommand(entityObject);
        ConnectionState oldConnectionState = command.Connection.State;
        try
        {
            if (oldConnectionState != ConnectionState.Open)
                command.Connection.Open();
            int result = command.ExecuteNonQuery();
            return result;
        }
        finally
        {
            if (oldConnectionState != ConnectionState.Open)
                command.Connection.Close();
        }
    }
    public DbCommand GenerateUpdateCommand(object entityObject)
    {
        ObjectContext objectContext = ((IObjectContextAdapter)Context).ObjectContext;
        var metadataWorkspace = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace();
        IEnumerable<EntitySetMapping> entitySetMappingCollection = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings;
        IEnumerable<AssociationSetMapping> associationSetMappingCollection = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().AssociationSetMappings;
        string entityTypeName;
        if (!entityObject.GetType().Namespace.Contains("DynamicProxi"))
            entityTypeName = entityObject.GetType().Name;
        else
            entityTypeName = entityObject.GetType().BaseType.Name;
        var entitySetMappings = entitySetMappingCollection.First(o => o.EntityTypeMappings.Select(e => e.EntityType.Name).Contains(entityTypeName));
        var entityTypeMapping = entitySetMappings.EntityTypeMappings[0];
        string tableName = entityTypeMapping.EntitySetMapping.EntitySet.Name;
        MappingFragment mappingFragment = entityTypeMapping.Fragments[0];
        string sqlColumns = string.Empty;
        int paramCount = 0;
        DbCommand command = Context.Database.Connection.CreateCommand();
        foreach (PropertyMapping propertyMapping in mappingFragment.PropertyMappings)
        {
            if (((ScalarPropertyMapping)propertyMapping).Column.StoreGeneratedPattern != StoreGeneratedPattern.None)
                continue;
            string columnName = ((ScalarPropertyMapping)propertyMapping).Column.Name;
            if (entityTypeMapping.EntityType.KeyProperties.Select(_ => _.Name).Contains(columnName))
                continue;
            object columnValue = entityObject.GetType().GetProperty(propertyMapping.Property.Name).GetValue(entityObject, null);
            string paramName = string.Format("@p{0}", paramCount);
            if (paramCount != 0)
                sqlColumns += ",";
            sqlColumns += string.Format("{0} = {1}", SqlQuote(columnName), paramName);
            DbParameter parameter = command.CreateParameter();
            parameter.Value = columnValue ?? DBNull.Value;
            parameter.ParameterName = paramName;
            command.Parameters.Add(parameter);
            paramCount++;
        }
        foreach (var navigationProperty in entityTypeMapping.EntityType.NavigationProperties)
        {
            PropertyInfo propertyInfo = entityObject.GetType().GetProperty(navigationProperty.Name);
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                continue;
            AssociationSetMapping associationSetMapping = associationSetMappingCollection.First(a => a.AssociationSet.ElementType.FullName == navigationProperty.RelationshipType.FullName);
            EndPropertyMapping propertyMappings = associationSetMapping.AssociationTypeMapping.MappingFragment.PropertyMappings.Cast<EndPropertyMapping>().First(p => p.AssociationEnd.Name.EndsWith("_Target"));
            object relatedObject = propertyInfo.GetValue(entityObject, null);
            foreach (ScalarPropertyMapping propertyMapping in propertyMappings.PropertyMappings)
            {
                string columnName = propertyMapping.Column.Name;
                string paramName = string.Format("@p{0}", paramCount);
                object columnValue = relatedObject == null ?
                    null :
                    relatedObject.GetType().GetProperty(propertyMapping.Property.Name).GetValue(relatedObject, null);
                if (paramCount != 0)
                    sqlColumns += ",";
                sqlColumns += string.Format("{0} = {1}", SqlQuote(columnName), paramName);
                DbParameter parameter = command.CreateParameter();
                parameter.Value = columnValue ?? DBNull.Value;
                parameter.ParameterName = paramName;
                command.Parameters.Add(parameter);
                paramCount++;
            }
        }
        string sqlWhere = string.Empty;
        bool first = true;
        foreach (EdmProperty keyProperty in entityTypeMapping.EntityType.KeyProperties)
        {
            var propertyMapping = mappingFragment.PropertyMappings.First(p => p.Property.Name == keyProperty.Name);
            string columnName = ((ScalarPropertyMapping)propertyMapping).Column.Name;
            object columnValue = entityObject.GetType().GetProperty(propertyMapping.Property.Name).GetValue(entityObject, null);
            string paramName = string.Format("@p{0}", paramCount);
            if (first)
                first = false;
            else
                sqlWhere += " AND ";
            sqlWhere += string.Format("{0} = {1}", SqlQuote(columnName), paramName);
            DbParameter parameter = command.CreateParameter();
            parameter.Value = columnValue;
            parameter.ParameterName = paramName;
            command.Parameters.Add(parameter);
            paramCount++;
        }
        string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, sqlColumns, sqlWhere);
        command.CommandText = sql;
        return command;
    }
