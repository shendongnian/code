    private void FinalizeWorkbook(DataTableReportParam reportParam, DataGridView dataGridViewControl)
        {
            FileInfo newFile = new FileInfo(reportParam.FileName);
            ExcelPackage pck = new ExcelPackage(newFile);
            IWorksheet worksheet = pck.Workbook.Worksheets[1];
            // wrap text and color the crashes with problems (header)
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                worksheet[1, col].WrapText = true;
                worksheet[1, col].AutofitRows();
                if (String.Compare(dataGridViewControl[col - 1, 0].Style.BackColor.Name, "0") != 0)
                    worksheet[1, col].CellStyle.Color = dataGridViewControl[col - 1, 0].Style.BackColor;
            }
            //
            // color the cells
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    if (String.Compare(dataGridViewControl[col - 1, row - 1].Style.BackColor.Name, "0") != 0)
                        worksheet[row, col].CellStyle.Color = dataGridViewControl[col - 1, row - 1].Style.BackColor;
                }
            }
            //
            //save and dispose
            pck.Save();
            pck.Dispose();
            
        }
