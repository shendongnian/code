    var depSectGroups = workTable.AsEnumerable()
        .GroupBy(row => new {DepartmentID = row.Field<string>("DepartmentID"), SectionID = row.Field<string>("SectionID")});
    DataTable resultTable = workTable.Clone();
    foreach (var rowGroup in depSectGroups)
    {
        if (rowGroup.Count() == 1)
            resultTable.ImportRow(rowGroup.First());
        else
        {
            DataRow addedRow = resultTable.Rows.Add();
            foreach (DataRow row in rowGroup)
            {
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (addedRow.IsNull(col.ColumnName) && !row.IsNull(col))
                        addedRow[col.ColumnName] = row[col];
                }
            }
        }
    }
