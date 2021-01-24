    public void DeleteCell(ExcelWorksheet worksheet, string cellAddress)
        {
            if (worksheet.Cells[cellAddress].Merge == true)
            {
                var value = worksheet.Cells[cellAddress].Value;
                string range = GetMergedRange(worksheet, cellAddress); //get range of merged cells
                worksheet.Cells[range].Merge = false; //unmerge range
                worksheet.Cells[cellAddress].Clear(); //clear value
                //merge the cells you want again.
                //fill the value in cells again
            }
        }
