     ExcelApp.Visible = true;
            foreach (Excel.Worksheet Worksheet in WB.Worksheets)
            {
                if (toProtect.Contains(Worksheet.Name))
                {
                    ((Excel.Worksheet)WB.Worksheets[Worksheet.Name]).Protect(Password);
                }
            }
            //WB.Save();
            ExcelApp.Visible = false;
