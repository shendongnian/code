    var nameQuery = tableMetaData
        .Where(table => (table.IsAuditTable == filterData.IsAuditTable)
            && (table.IsSyncTable == filterData.IsSyncTable)
            && (table.IsView == filterData.IsView));
    if (filterData.TableName != null)
         nameQuery = nameQuery.Where(table => table.TableName == filterData.TableName);
    if (filterData.ReferenceTableName != null)
         nameQuery = nameQuery.Where(table => table.ReferenceTableName == filterData.ReferenceTableName);
    // more criteria ..
    return  nameQuery.Select(table => table.TableName).ToList();
