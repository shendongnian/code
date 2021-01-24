        private int ProcessRange(Excel.Range my_range)
        {
            // Get a range, containing all rows, within my_range.
            int rows = my_range.Rows.Count;
            int cols = my_range.Columns.Count;
            Excel.Range c1 = my_range.Cells[1, 1];           
            Excel.Range c2 = my_range.Cells[rows, cols];
            Excel.Worksheet ws = my_range.Worksheet;
            Excel.Range range2 = (Excel.Range)ws.Range[c1, c2];
            string value2 = range2.Cells[1, 1].Value;
            Console.WriteLine(value2);
            return 0;
        }
