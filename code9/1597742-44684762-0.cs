    private void Email()
    {
        //get the data from database
        DataTable data = GetData();
        int maxLavel = Convert.ToInt32(data.Compute("max([AssignedID])", string.Empty));
        IWorkbook workbook;
        workbook = new HSSFWorkbook();
        
        for (int Emp = 0; Emp < maxLavel; Emp++)
        {
            ISheet sheet1 = workbook.CreateSheet("Sheet 1");
            int num = 0;
            //make a header row  
            IRow row1 = sheet1.CreateRow(0);
            for (int j = 0; j < data.Columns.Count; j++)
            {
                ICell cell = row1.CreateCell(j);
                String columnName = data.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }
                //loops through data  
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i + 1);
                    if (Emp == Convert.ToInt32(data.Rows[i][0]))
                    {
                        num++;
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            sheet1.AutoSizeColumn(j); //control cell width
                            String columnName = data.Columns[j].ToString();
                            cell.SetCellValue(data.Rows[i][columnName].ToString());
                        }
                    }
                }
                if (num != 0)
                {
                //send email
                }
            workbook.remove(sheet1);
        }
    }
