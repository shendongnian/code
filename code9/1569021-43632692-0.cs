            foreach (var columnName in lines.FirstOrDefault()
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                dataGridView1.Rows.Add(Time, Class);
            }
            foreach (var cellValues in lines.Skip(1)) //skip the first line as it contains our headers
            {
                var cellArray = cellValues
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (cellArray.Length == dataGridView1.Columns.Count)
                    dataGridView1.Rows.Add(cellArray);
            }
