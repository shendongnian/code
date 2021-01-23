    string workSheetSQL = "Select * From [WorkSheetTable]";
    using (SqlConnection cnn = new SqlConnection("connection string here"))
    {
    using (SqlCommand sheetCommand = new SqlCommand(workSheetSQL, cnn))
    {
        using (SqlDataReader sheetReader = sheetCommand.ExecuteReader())
        {
            while (sheetReader.Read())
            {
				SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
				SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
				SpreadsheetGear.IRange cells = worksheet.Cells;
		 
				// Set the worksheet name.
				worksheet.Name = sheetReader["WBSheetName"].ToString();
		        //I assume FunctionWBId value is foreign key for cell Table, otherwise remove WHERE clause from following sql query
                string cellsSQL = "Select * From [CellsTable] where FunctionWBId = "+sheetReader["FunctionWBId"].ToString();
				// Load cell values.
				
                using (SqlCommand cellCommand = new SqlCommand(cellsSQL, cnn))
				{
					using (SqlDataReader cellReader = cellCommand.ExecuteReader())
					{
						while (cellReader.Read())
						{
							cells[cellReader["ExcelCellNo"]ToString()].Value = cellReader["IOValue"].ToString();
                            //Add more properties to each cell if you wish in the same way
						}
					}					
				}
				workbook.SaveAs(sheetReader["WBLocation"].ToString()); 
                //Add more properties to workbook if you wish in the same way
            }
        }
    }
    }
