    #region Read value from excel combobox
                        Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel._Workbook oWB;
                        Microsoft.Office.Interop.Excel._Worksheet oSheet;
                        Microsoft.Office.Interop.Excel.Range oRng;
            
                        //Get a new workbook.
                        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Open("C:\\TopicUpload_2017October14.xls"));
                        //3rd Sheet
                        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.Sheets.get_Item(1);
            
                        Microsoft.Office.Interop.Excel.DropDowns allDropDowns = oSheet.DropDowns(Type.Missing);
                        Microsoft.Office.Interop.Excel.DropDown oneDropdown = allDropDowns.Item("1"); // first combo
                        string selectedText = oneDropdown.get_List(oneDropdown.ListIndex); 
        #endregion
