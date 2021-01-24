            //Open your template file.
            Workbook wb = new Workbook("e:\\test2\\Book1.xlsx");
            //Get the first worksheet.
            Worksheet worksheet = wb.Worksheets[0];
            //Get the cells collection.
            Cells cells = worksheet.Cells;
            
            //Define the list.
            List<string> myList = new List<string>();
            //Get the AA column index. (Since "Status" is always @ AA column.
            int col = CellsHelper.ColumnNameToIndex("AA");
            
            //Get the last row index in AA column.
            int last_row = worksheet.Cells.GetLastDataRow(col);
            //Loop through the "Status" column while start collecting values from row 9
            //to save each value to List
            for (int i = 8; i <= last_row; i++)
            {
                myList.Add(cells[i, col].Value.ToString());
            } 
        } 
