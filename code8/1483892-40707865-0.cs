        public void ReplaceChartValuesLinearChart(string placeholderCaption, System.Data.DataTable chartData, string newCaption)
        {
            if (wordDocument != null)
            {
                try
                {
                    // Get the exact Chart Part where Caption matches the place holder value.
                    ChartPart target = mainDocumentPart
                        .ChartParts
                        .Where(r => r
                            .ChartSpace
                            .GetFirstChild<Chart>()
                            .Title
                            .InnerText
                            .StartsWith(placeholderCaption)
                        )
                        .FirstOrDefault();
                    if (target != null)
                    {
                        // Set the new caption.
                        target
                            .ChartSpace
                            .GetFirstChild<Chart>()
                            .Title
                            .ChartText
                            .RichText
                            .GetFirstChild<DocumentFormat.OpenXml.Drawing.Paragraph>()
                            .GetFirstChild<DocumentFormat.OpenXml.Drawing.Run>()
                            .Text
                            .Text = newCaption;
                        // Update all NumberingCache values to reflect total number of records.
                        foreach (NumberingCache currentNumberingCache in target.ChartSpace.Descendants<NumberingCache>())
                        {
                            currentNumberingCache.PointCount = new PointCount() { Val = (DocumentFormat.OpenXml.UInt32Value)(UInt32)chartData.Rows.Count };
                            currentNumberingCache.RemoveAllChildren<NumericPoint>();
                        }
                        // Set the Numeric Point values with formats and add to the appropriate NumberingCache.
                        for (int ctr = 0; ctr < chartData.Rows.Count; ctr++)
                        {
                            // First Range - contains date.
                            NumericPoint newNumericPoint = new NumericPoint();
                            newNumericPoint.Index = new DocumentFormat.OpenXml.UInt32Value((uint)ctr);
                            newNumericPoint.FormatCode = "[$-409]ddmmmyyyy";
                            newNumericPoint.NumericValue = new NumericValue(chartData.Rows[ctr][0].ToString());
                            target
                                .ChartSpace
                                .Descendants<NumberingCache>()
                                .ToArray()[0]
                                .AppendChild(newNumericPoint);
                            // Third Range - contains date.
                            newNumericPoint = new NumericPoint();
                            newNumericPoint.Index = new DocumentFormat.OpenXml.UInt32Value((uint)ctr);
                            newNumericPoint.FormatCode = "[$-409]ddmmmyyyy";
                            newNumericPoint.NumericValue = new NumericValue(chartData.Rows[ctr][0].ToString());
                            target
                                .ChartSpace
                                .Descendants<NumberingCache>()
                                .ToArray()[2]
                                .AppendChild(newNumericPoint);
                            // Second Range - contains reference data.
                            if (chartData.Rows[ctr][2] != DBNull.Value)
                            {
                                newNumericPoint = new NumericPoint();
                                newNumericPoint.Index = new DocumentFormat.OpenXml.UInt32Value((uint)ctr);
                                newNumericPoint.FormatCode = "0.00%";
                                newNumericPoint.NumericValue = new NumericValue(chartData.Rows[ctr][2].ToString());
                                target
                                    .ChartSpace
                                    .Descendants<NumberingCache>()
                                    .ToArray()[1]
                                    .AppendChild(newNumericPoint);
                            }
                            // Second Range - contains current data.
                            if (chartData.Rows[ctr][3] != DBNull.Value)
                            {
                                newNumericPoint = new NumericPoint();
                                newNumericPoint.Index = new DocumentFormat.OpenXml.UInt32Value((uint)ctr);
                                newNumericPoint.FormatCode = "0.00%";
                                newNumericPoint.NumericValue = new NumericValue(chartData.Rows[ctr][3].ToString());
                                target
                                    .ChartSpace
                                    .Descendants<NumberingCache>()
                                    .ToArray()[3]
                                    .AppendChild(newNumericPoint);
                            }
                        }
                        // Update all variable length formula to point to updated number of rows.
                        foreach (var currentFormula in target.ChartSpace.Descendants<Formula>())
                        {
                            if (currentFormula.Text.Contains(":"))
                            {
                                currentFormula.Text =
                                    currentFormula.Text.Substring(0, currentFormula.Text.LastIndexOf("$") + 1)
                                    + (chartData.Rows.Count + 1).ToString();
                            }
                        }
                        // Get handle to ExternalData for accessing embedded Excel document.
                        ExternalData externalData =
                            target
                            .ChartSpace
                            .Elements<ExternalData>()
                            .FirstOrDefault();
                        if (externalData != null)
                        {
                            // Get handle to Package Part containing excel document.
                            EmbeddedPackagePart embeddedPackagePart =
                                (EmbeddedPackagePart)
                                target
                                .Parts
                                .Where(r => r.RelationshipId == externalData.Id)
                                .FirstOrDefault()
                                .OpenXmlPart;
                            if (embeddedPackagePart != null)
                            {
                                // Get handle to Stream for modifying data.
                                using (Stream stream = embeddedPackagePart.GetStream())
                                {
                                    // Open Excel for manipulation.
                                    using (SpreadsheetDocument spreadsheetDocument = 
                                        SpreadsheetDocument.Open(stream, true))
                                    {
                                        // Get handle to first sheet.
                                        DocumentFormat
                                            .OpenXml
                                            .Spreadsheet
                                            .Sheet worksheet = (DocumentFormat.OpenXml.Spreadsheet.Sheet)
                                                spreadsheetDocument
                                                .WorkbookPart
                                                .Workbook
                                                .Sheets
                                                .FirstOrDefault();
                                        // Get handle to first worksheet.
                                        WorksheetPart worksheetPart = (WorksheetPart)
                                            spreadsheetDocument
                                            .WorkbookPart
                                            .Parts
                                            .Where(r => r.RelationshipId == worksheet.Id)
                                            .FirstOrDefault()
                                            .OpenXmlPart;
                                        // Set Table range on the first worksheet.
                                        worksheetPart
                                            .TableDefinitionParts
                                            .FirstOrDefault()
                                            .Table
                                            .Reference
                                            .Value = "A1:D" + (chartData.Rows.Count + 1).ToString();
                                        // Get handle to access entire sheet data.
                                        DocumentFormat
                                            .OpenXml
                                            .Spreadsheet
                                            .SheetData sheetData =
                                                worksheetPart
                                                .Worksheet
                                                .Elements<DocumentFormat.OpenXml.Spreadsheet.SheetData>()
                                                .FirstOrDefault();
                                        // Select all data rows.
                                        var existingRows = sheetData
                                            .Elements<DocumentFormat.OpenXml.Spreadsheet.Row>()
                                            .Skip(1)
                                            .ToArray();
                                        // Remove all existing data rows.
                                        for (int ctr = 0; ctr < existingRows.Length; ctr++)
                                        {
                                            sheetData
                                                .RemoveChild<DocumentFormat.OpenXml.Spreadsheet.Row>(existingRows[ctr]);
                                        }
                                        // Create new rows.
                                        for (int ctr1 = 0; ctr1 < chartData.Rows.Count; ctr1++)
                                        {
                                            DocumentFormat
                                                .OpenXml
                                                .Spreadsheet
                                                .Row newRecord = new 
                                                    DocumentFormat
                                                    .OpenXml
                                                    .Spreadsheet.Row();
                                            // Set values and formats for each cell for new row.
                                            for (int ctr2 = 0; ctr2 < chartData.Columns.Count; ctr2++)
                                            {
                                                // Create a new cell.
                                                DocumentFormat
                                                    .OpenXml
                                                    .Spreadsheet
                                                    .Cell newCell = new 
                                                        DocumentFormat
                                                        .OpenXml
                                                        .Spreadsheet
                                                        .Cell();
                                                // Create a new cell value for holding actual value of the cell.
                                                DocumentFormat
                                                    .OpenXml
                                                    .Spreadsheet
                                                    .CellValue newCellValue = new 
                                                        DocumentFormat
                                                        .OpenXml
                                                        .Spreadsheet
                                                        .CellValue();
                                                // Set appropriate Style, Data Type and value for the cell.
                                                switch (ctr2)
                                                {
                                                    case 0:
                                                        newCell.StyleIndex = new 
                                                                DocumentFormat
                                                                .OpenXml
                                                                .UInt32Value((uint)2);
                                                        newCellValue.Text = 
                                                            chartData.Rows[ctr1][ctr2].ToString();
                                                        break;
                                                    case 1:
                                                        newCellValue.Text = 
                                                            GetSharedStringIndex(
                                                                    spreadsheetDocument
                                                                    .WorkbookPart
                                                                    .SharedStringTablePart, 
                                                                    chartData.Rows[ctr1][ctr2].ToString());
                                                        newCell.StyleIndex = new 
                                                            DocumentFormat
                                                            .OpenXml
                                                            .UInt32Value((uint)2);
                                                        newCell.DataType = 
                                                                DocumentFormat
                                                                .OpenXml
                                                                .Spreadsheet
                                                                .CellValues
                                                                .SharedString;
                                                        break;
                                                    case 2:
                                                    case 3:
                                                        newCellValue.Text = 
                                                            chartData.Rows[ctr1][ctr2].ToString();
                                                        if (chartData.Rows[ctr1][ctr2] != DBNull.Value && 
                                                            chartData.Rows[ctr1][ctr2].ToString().Trim().Length > 0)
                                                        {
                                                            newCell.StyleIndex = new 
                                                                DocumentFormat
                                                                .OpenXml
                                                                .UInt32Value((uint)3);
                                                        }
                                                        else
                                                        {
                                                            newCell.StyleIndex = new 
                                                                DocumentFormat
                                                                .OpenXml
                                                                .UInt32Value((uint)1);
                                                        }
                                                        break;
                                                }
                                                // Append newly created cell value to the cell.
                                                newCell.AppendChild(newCellValue);
                                                // Append newly created cell to the Row.
                                                newRecord.AppendChild(newCell);
                                            }
                                            // Append newly created row to the Excel sheet.
                                            sheetData.AppendChild(newRecord);
                                        }
                                        spreadsheetDocument.Save();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    // Save the document.
                    mainDocumentPart.Document.Save();
                }
            }
        }
        private string GetSharedStringIndex(SharedStringTablePart sharedStringTablePart, string valueToSearch)
        {
            int counter = 0;
            // Return index if item already exists.
            foreach (DocumentFormat.OpenXml.Spreadsheet.SharedStringItem currentItem in sharedStringTablePart.SharedStringTable.Elements<DocumentFormat.OpenXml.Spreadsheet.SharedStringItem>())
            {
                if (currentItem.InnerText == valueToSearch)
                {
                    return counter.ToString();
                }
                counter++;
            }
            // The text does not exist in the part. Create the SharedStringItem and return its index.
            sharedStringTablePart.SharedStringTable.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(valueToSearch)));
            sharedStringTablePart.SharedStringTable.Save();
            return counter.ToString();
        }
