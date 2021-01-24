            //you are adding rows to the column here, you are not adding headers 
            foreach (
              var columnName in 
              lines.FirstOrDefault().Split(new[] {','}, 
              StringSplitOptions.RemoveEmptyEntries)
            )
            {
                //since we split the line on commas, 
                //we are adding a row to the table for every 
                //CSV value we found in the current line. 
                //this is causing the "garbage" rows you are seeing
                //i do not know where "Time" and "Class" come from here. 
                //they weren't part of that first line in this example. 
                //my guess is you do not need this loop at all.
                //since the headers already neatly show up on the table in your screenshot.
                dataGridView1.Rows.Add(Time, Class);
            }
            //this works just fine.
            foreach (var cellValues in lines)
            {
                var cellArray = cellValues
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (cellArray.Length == dataGridView1.Columns.Count)
                    dataGridView1.Rows.Add(cellArray);
            }
