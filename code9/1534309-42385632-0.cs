            List<Task> tasks = new List<Task>();
            for (int j = 0; j < RowCount - 1; j++)
            {
                for (int k = 0; k < ColumnCount - 1; k++)
                {
                    GridCell currentCell = GetCurrentCell(Slice1, Slice2, j, k);
                    
                    // Start a new Task and add it to collection
                    tasks.Add(Task.Factory.StartNew(() => 
                    {
                        Polygonise(ref Triangles, isoLevel, GridCell currentCell);
                    }));
                }
            }
       
            // Waiting for the completion of all tasks
            Task.WaitAll(tasks.ToArray());
