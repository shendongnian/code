    private void SearchText()
            {
                string File_name = "D:\\test.xlsx";
                Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook oWB;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;
                try
                {
                    object missing = System.Reflection.Missing.Value;
                    oWB = oXL.Workbooks.Open(File_name, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing);
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets[1];
                    Microsoft.Office.Interop.Excel.Range oRng = GetSpecifiedRange("test", oSheet);
                    if (oRng != null)
                    {
                        MessageBox.Show("Text found, position is Row:" + oRng.Row + " and column:" + oRng.Column);
                    }
                    else
                    {
                        MessageBox.Show("Text is not found");
                    }
                    oWB.Close(false, missing, missing);
     
                    oSheet = null;
                    oWB = null;
                    oXL.Quit();
                }
                catch (Exception ex)
                {
     
                }
            }
