    var items = from pair in MDBContent.AsParallel()
                let indexedRows =pair.Value.Rows.OfType<DataRow>().Select((row,idx)=>new {Row=row,Idx=idx})                
                from indexedRow in indexedRows
                from DataColumn column in pair.Value.Columns
                let field=indexedRow.Row[column].ToString()
                where field.Contains(searchText)
                select new ListViewItemClass
                {
                    Page = pair.Key,
                    Column = column.Caption,
                    Row = (indexedRow.Idx +1).ToString(),
                    ItemValue = field
                };
