        // decide what order to use
        return result;
    }
    class MyDataRow : DataRow
    {
        MyDataRow(TableData tableData)
        {
            // extract the data you want in the table
        }
    }
    IOrderedEnumerable<TableData> orderedTableData = OrderedQueryResult(
        untouchedItems, deletedItems, newestAuditData);
    IEnumerable<MyDataRow> dataRows = orderedTableData
        .Select(tableData => new MyDataRow(tableData);
    DataTable myTable = dataRows.CopyToDataTable();
