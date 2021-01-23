                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Open("c:\\Users\\username\\Desktop\\Test.xlsx");
                Excel.Worksheet excelworksheet = excelWorkBook.ActiveSheet;
                Excel.Worksheet sheet2 = excelWorkBook.Sheets.Add(); // Added new sheet to create Pivot Table
                sheet2.Name = "Pivot Table"; // Assigned sheet Name
                excelworksheet.Activate();
                Excel.Range oRange = excelworksheet.UsedRange;
                Excel.PivotCache oPivotCache = (Excel.PivotCache)excelWorkBook.PivotCaches().Add(Excel.XlPivotTableSourceType.xlDatabase, oRange);  // Set the Source data range from First sheet
                Excel.Range oRange2 = sheet2.Cells[1, 1];
                Excel.PivotCaches pch = excelWorkBook.PivotCaches();
                pch.Add(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, oRange).CreatePivotTable(sheet2.Cells[1, 1], "PivTbl_1", Type.Missing, Type.Missing);// Create Pivot table
                Excel.PivotTable pvt = sheet2.PivotTables("PivTbl_1") as Excel.PivotTable;
                pvt.ShowDrillIndicators = false;  // Used to remove the Expand/ Collapse Button from each cell
                Excel.PivotField fld = ((Excel.PivotField)pvt.PivotFields("ColumnA")); // Create a Pivot Field in Pivot table
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField; // Add the pivot field as Row Field
                fld.set_Subtotals(1, false); //Remove Subtotals for each row and column 
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnB"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnC"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnD"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnE"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnF"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnG"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnH"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                fld.set_Subtotals(1, false);
                fld = ((Excel.PivotField)pvt.PivotFields("ColumnI"));
                fld.Orientation = Excel.XlPivotFieldOrientation.xlDataField; // Sort column set as datafield to show the Pivot table as per requirement- It will show the total count of data and not needed so later on we will hide this Column
                sheet2.UsedRange.Columns.AutoFit();  // Used to Autoset the column width according to data 
                //Set Conditional Formating for "Access" Column if Cell of the Access Column Contain W then Set Background color Light Green/ If R then Set Misty Rose Cell's Back Ground Color
                Excel.FormatCondition SetBgColorForAccessW = sheet2.get_Range("H:H", Type.Missing).FormatConditions.Add(Excel.XlFormatConditionType.xlTextString, Type.Missing, Type.Missing, Type.Missing, "w", Excel.XlContainsOperator.xlContains, Type.Missing, Type.Missing);
                SetBgColorForAccessW.Interior.Color = Color.LightGreen;
                Excel.FormatCondition SetBgColorForAccessR = sheet2.get_Range("H:H", Type.Missing).FormatConditions.Add(Excel.XlFormatConditionType.xlTextString, Type.Missing, Type.Missing, Type.Missing, "r", Excel.XlContainsOperator.xlContains, Type.Missing, Type.Missing);
                SetBgColorForAccessR.Interior.Color = Color.MistyRose;
                
                sheet2.get_Range("I:I").EntireColumn.Hidden = true; // Used to hide Sort Column as not needed and not have relavent data
                pvt.ColumnGrand = false;  // Used to hide Grand total for columns
                pvt.RowGrand = false; // Used to hide Grand total for Rows
                excelApp.DisplayAlerts = false;  // Used to hide unappropriate message prompt from Excel
                excelworksheet.Delete(); // Delete the Sheet with Raw data because not needed and we created new sheet which represent data in pivot table format
                sheet2.Activate(); // Set focus on Sheet Containing data in Pivot table format
                sheet2.get_Range("J1", "J1").Select(); // Set focus of column J to hide Pivot Table Field List (Left pane) when we open the file
                excelWorkBook.SaveAs(OutputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);// Used to Save as and overwrite the Excel file if already exist
                excelApp.DisplayAlerts = true;  // Reset the property of Excel
                excelWorkBook.Close(); // Close the workbook
                excelApp.Quit(); // Quit the Excel application;
