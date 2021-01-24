     public static void SetFormulasColumnwise(Range dataRange, IReadOnlyCollection<string> columnFormulas)
        {
           
           
            try
            {
                foreach (Range c in dataRange.Cells)
                   //c.Row.ToString() returns the current row index
                    c.FormulaLocal = columnFormulas.ElementAt((int.Parse(c.Row.ToString())-1)  % (columnFormulas.Count()));
            }
            catch (COMException)
            {
                MessageBox.Show("Failed to set column formulas "
                                +
                                "Please make sure the formula is valid\n" +
                                "and that the workbook is writable.",
                    "Error");
                throw;
            }
        }
