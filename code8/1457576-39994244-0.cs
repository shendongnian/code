    package.Load(fileContent.InputStream);
    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
    int totalRows = workSheet.Dimension.End.Row;
    int totalCols = workSheet.Dimension.End.Column;
    List<myObject> listMyObject = new List<myObject>();
    for (int currentRow = 1; currentRow <= totalRows; currentRow++)
    {
        string[] resultRow = new string[totalCols];
        for (int currentCol = 1; currentCol <= totalCols; currentCol++)
        {
            //We read the entire line and store it in the array
            resultRow[currentCol - 1] = (workSheet.Cells[currentRow, currentCol].Value != null) ? workSheet.Cells[currentRow, currentCol].Value.ToString() : "";
        }
       //And now I can bind my array to my object
       listMyObject.Add(myObjectHelper.Convert(resultRow));
    }
    //Here i've got my list object
