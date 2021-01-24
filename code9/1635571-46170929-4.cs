    var items = from KeyValuePair<string, DataTable> pair in MDBContent
                from DataRow row in pair.Value.Rows
                from DataColumn column in pair.Value.Columns
                let field=row[column].ToString()
                where field.Contains(searchText)
                select new ListViewItemClass
                {
                    Page = pair.Key,
                    Column = column.Caption,
    //                Row = (RowIndex + 1).ToString(),
                    ItemValue = field
                };
