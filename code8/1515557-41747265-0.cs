    public List<string> GetTableNames(TableMetaData filterData)
    {
        List<string> filteredNames = tableMetaData
            .Where(table => (table.IsAuditTable == filterData.IsAuditTable)
                && (table.IsSyncTable == filterData.IsSyncTable)
                && (table.IsView == filterData.IsView)
            && (string.IsNullOrEmpty(filterData.ReferenceTableName) || table.TableName == filterData.TableName)
            && (string.IsNullOrEmpty(filterData.ReferenceTableName) || table.ReferenceTableName == filterData.ReferenceTableName))
            .Select(table => table.TableName).ToList();
        return filteredNames;
    }
