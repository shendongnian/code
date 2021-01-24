    DataTable uploadtable = dataTable.Copy();
    var removeColumns = dataTable.Columns.Cast<DataColumn>()
       .Where(c => !c.ColumnName.StartsWith("hz", StringComparison.InvariantCultureIgnoreCase));
    foreach (DataColumn colToRemove in removeColumns)
        uploadtable.Columns.Remove(colToRemove.ColumnName);
