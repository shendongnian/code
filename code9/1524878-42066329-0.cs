        public string Export(DataTable dt)
        {
            Workbook workbook = new Workbook();
            Worksheet sheet = new Worksheet(WorkSheetName);
            workbook.Worksheets.Add(sheet);
            // Adding Columns in Sheet
            int c = 0, r = 0;
            foreach (DataColumn column in dt.Columns)
            {
                sheet.Cells[r, c] = new Cell(column.ColumnName);
                c++;
            }
            // Adding Records into sheet
            r = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (c = 0; c < dt.Columns.Count; c++)
                {
                    object o = dt.Rows[i][c];
                    int ii;
                    if (o == DBNull.Value)
                        sheet.Cells[r, c] = new Cell("");
                    else if (int.TryParse(o.ToString(), out ii))
                        sheet.Cells[r, c] = new Cell(ii);
                    else
                        sheet.Cells[r, c] = new Cell(o);
                }
                r++;
            }
            // Append Extra rows to comfort Open excel > 2003
            if (dt.Rows.Count < MinRow)
            {
                r++;
                for (int i = 0; i < MinRow; i++)
                {
                    for (c = 0; c < 50; c++)
                    {
                        sheet.Cells[r, c] = new Cell("");
                    }
                    r++;
                }
            }
            string fileName = Guid.NewGuid().ToString("N") + ".xls";
            if (!Directory.Exists(DestinationRootFolder))
            {
                Directory.CreateDirectory(DestinationRootFolder);
            }
            workbook.Save(fileName);
            return fileName;
        }
