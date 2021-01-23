    public List<string> GetTableNames(TableMetaData filterData)
    {
        List<string> filteredNames = tableMetaData
            .Where(table => (table.IsAuditTable == filterData.IsAuditTable)
                && (table.IsSyncTable == filterData.IsSyncTable)
                && (table.IsView == filterData.IsView)
                && ((table.TableName == null) || (table.TableName == "Something"))
                && ((table.ReferenceTableName == null) || (table.ReferenceTableName == "Something")))
            .Select(table => table.TableName).ToList();
        return filteredNames;
    }
