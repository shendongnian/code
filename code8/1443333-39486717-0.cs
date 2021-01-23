    using Excel = Microsoft.Office.Interop.Excel;
    using VBE = Microsoft.Vbe.Interop.Forms;
    private static void ExcelOperation(string xlFileName)
            {
                var xlApp = new Excel.Application();
                var xlWorkbook = xlApp.Workbooks.Open(xlFileName);
                var xlSheet = xlWorkbook.Worksheets["your_sheet_Name"] as Excel.Worksheet;
    
                try
                {
                    Excel.OLEObjects oleObjects = xlSheet.OLEObjects() as Excel.OLEObjects;
                    foreach (Excel.OLEObject item in oleObjects)
                    {                   
                        if (item.progID == "Forms.TextBox.1")
                        {
                            VBE.TextBox xlTB = item.Object as VBE.TextBox;
                            Console.WriteLine("Name: " + item.Name);
                            Console.WriteLine("Text: " + xlTB.Text);
                            Console.WriteLine("Value: " + xlTB.get_Value());
                            Marshal.ReleaseComObject(xlTB); xlTB = null;
                        }
                        else if (item.progID == "Forms.CheckBox.1")
                        {
                            VBE.CheckBox xlCB = item.Object as VBE.CheckBox;
                            Console.WriteLine("checkbox: " + item.Name);
                            Console.WriteLine("Value: " + xlCB.get_Value());
                            Marshal.ReleaseComObject(xlCB); xlCB = null;
                        }                    
                        
                    }
    
                    Marshal.ReleaseComObject(oleObjects); oleObjects = null;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                Marshal.ReleaseComObject(xlSheet); xlSheet = null;
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook); xlWorkbook = null;
                Marshal.ReleaseComObject(xlApp); xlApp = null;
            }
