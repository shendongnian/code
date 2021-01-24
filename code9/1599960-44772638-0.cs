      // grid Columns with respect to their data fields
            Dictionary<string, DataControlField> gridColumns = new Dictionary<string, DataControlField>();
            for (int record = 0; record < lettertable.Columns.Count; record++)
            {
                var gridColumn = lettertable.Columns[record];
                if (gridColumn is BoundField)
                {
                    var boundField = gridColumn as BoundField;
                    gridColumns.Add(boundField.DataField, gridColumn);
                }
            }
            // columns new arrangement
            string columnsOrder = "BAECD";
            for(int count= lettertable.Columns.Count-1; count>-1; count--) 
            {
                // remove existig columns
                lettertable.Columns.RemoveAt(count);
            }
            // add columsn
            foreach (var columnOrder in columnsOrder)
            {
                lettertable.Columns.Add(gridColumns[columnOrder.ToString()]);
            }
            // Bind grid to show new columns
            lettertable.DataBind();
