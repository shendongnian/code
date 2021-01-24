            table.Columns.Add("col1");
            table.Columns.Add("col2");
            table.Columns.Add("col3");
            var array = table.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToArray();
            foreach(var item in array)
            {
                MessageBox.Show(item);
            }
