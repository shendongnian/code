            Dictionary differencesByField = new Dictionary();
            for each row in differences.Rows
            {
                var columnId = ColumnId of row
                DataRow otherRow = get the row in dt2 with same columnId
                differencesByField[columnId] = new List<string>();
                for each column in differences.Columns
                {
                    string val = get value of column from row
                    string otherVal = get value of column from otherRow
                    if (val != otherVal)
                    {
                        differencesByField[columnId].Add(col.ColumnName);
                    }
                }
            }
