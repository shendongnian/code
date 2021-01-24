    IOrderedEnumerable<TableData> OrderQueryResult(
        IEnumerable<TableData> unTouchedItems,
        IEnumerable<TableData> deletedItems,
        IEnumerable<TableData> auditedItems)
    {
        // TODO decide what order to use
        return result;
    }
    class MyDataRow : DataRow
    {
        MyDataRow(TableData tableData)
        {
            // in the constructor, extract the data you want in the DataRow
        }
    }
    IOrderedEnumerable<TableData> orderedTableData = OrderedQueryResult(
        untouchedItems, deletedItems, newestAuditData);
    IEnumerable<MyDataRow> dataRows = orderedTableData
        .Select(tableData => new MyDataRow(tableData);
    DataTable myTable = dataRows.CopyToDataTable();
