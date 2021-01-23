    please try for another method, mentioned below
    
    Private void ExportDatasettoExcel(DataSet dsExcel)
    {
                //Add a workbook
    	    string fileName = @"C:\Sample.xls";
                CarlosAg.ExcelXmlWriter.Workbook book = new CarlosAg.ExcelXmlWriter.Workbook();
    
                // Specify which Sheet should be opened and the size of window by default
                book.ExcelWorkbook.ActiveSheetIndex = 1;
                book.ExcelWorkbook.WindowTopX = 100;
                book.ExcelWorkbook.WindowTopY = 200;
                book.ExcelWorkbook.WindowHeight = 7000;
                book.ExcelWorkbook.WindowWidth = 8000;
    
                // Some optional properties of the Document
                book.Properties.Author = "Murali";
                book.Properties.Title = "Excel Export";
                book.Properties.Created = DateTime.Now;
    
    	    //Add styles to the workbook 
                WorksheetStyle s31 =book.Styles.Add("s31");
                s31.Font.FontName = "Tahoma";
                s31.Font.Size = 8;
                s31.Font.Color = "#000000";
                s31.Alignment.Horizontal = StyleHorizontalAlignment.Center;
                s31.Alignment.Vertical = StyleVerticalAlignment.Center;
                s31.Alignment.WrapText = true;
                s31.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
                s31.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
                s31.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
                s31.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
                s31.NumberFormat = "@";
                
                // Add styles for header of the Workbook
                WorksheetStyle style = book.Styles.Add("HeaderStyle");
                style.Font.FontName = "Tahoma";
                style.Font.Size = 12;
                style.Font.Bold = true;
                style.Alignment.Horizontal = StyleHorizontalAlignment.Center;
                style.Font.Color = "White";
                style.Interior.Color = "Blue";
                style.Interior.Pattern = StyleInteriorPattern.DiagCross;
    
                
                // Add a Worksheet with some data
                Worksheet sheet = book.Worksheets.Add("Sample Data");
                // we can optionally set some column settings
                sheet.Table.Columns.Add(new WorksheetColumn(100));
                sheet.Table.Columns.Add(new WorksheetColumn(100));
                sheet.Table.Columns.Add(new WorksheetColumn(250));
                
                //Add row with some properties
                WorksheetRow row = sheet.Table.Rows.Add();
                row.Index = 0;
                row.Height = 26;
                row.AutoFitHeight = false;
               
    	    //Add header text for the columns	
                WorksheetCell wcHeader = new WorksheetCell("Column 1", "HeaderStyle");
                row.Cells.Add(wcHeader);
                wcHeader = new WorksheetCell("Column 2", "HeaderStyle");
                row.Cells.Add(wcHeader);
                wcHeader = new WorksheetCell("Column 3", "HeaderStyle");
                row.Cells.Add(wcHeader);           
                           
    	    //Loop through each table in dataset
                for (int i = 0; i < dsExcel.Tables.Count; i++)
                {
    		//Loop through each row in datatable                
                        foreach (DataRow dtrrow in dsExcel.Tables[i].Rows)
                        {                   
    			//Add row to the excel sheet
    			row = sheet.Table.Rows.Add();
                            row.Height = 30;
                            row.AutoFitHeight = false;
    			//Loop through each column
                            foreach (DataColumn col in dsExcel.Tables[i].Columns)
                            {
                                
                                    WorksheetCell wc = new WorksheetCell(dtrrow[col.ColumnName].ToString(), DataType.String, "s31");
                                    row.Cells.Add(wc);                            
                            }
                        }                
                }
    	    //Save the work book
                book.Save(fileName);
    }
