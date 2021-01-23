    private static readonly Color CONTRACT_ITEM_COLOR = Color.FromArgb(255, 255, 204);
    . . .
    private void AddPivotTable()
    {
        . . .
        List<String> contractItemDescs = GetContractItemDescriptions();
        ColorizeContractItemBlocks(contractItemDescs);
        . . .
    }
    
    private List<string> GetContractItemDescriptions()
    {
        int FIRST_PIVOTDATA_DATA_ROW = 2;
        int DESCRIPTION_COLUMN = 2;
        int CONTRACT_COLUMN = 7;
        List<string> descriptionsOfContractedItems = new List<string>();
        int pivotDataRowCount = _xlBook.Worksheets["PivotData"].UsedRange.Rows.Count;
    
        // Loop through the data sheet, adding the Descriptions for all Contract Items to the generic list
        for (int i = FIRST_PIVOTDATA_DATA_ROW; i <= pivotDataRowCount; i++)
        {
            Range contractItemCell = _xlPivotDataSheet.Cells[i, CONTRACT_COLUMN];
            if (contractItemCell.Value2.ToString().ToUpper() != "FALSE")
            {
                Range descriptionCell = _xlPivotDataSheet.Cells[i, DESCRIPTION_COLUMN];
                String desc = descriptionCell.Value2.ToString();
                descriptionsOfContractedItems.Add(desc);
            }
        }
        return descriptionsOfContractedItems;
    }
    
    private void ColorizeContractItemBlocks(List<string> contractItemDescs)
    {
        int FIRST_DESCRIPTION_ROW = 8;
        int DESCRIPTION_COL = 1;
        int ROWS_BETWEEN_DESCRIPTIONS = 5;
        int rowsUsed = _xlBook.Worksheets["PivotTable"].UsedRange.Rows.Count;
        int colsUsed = _xlBook.Worksheets["PivotTable"].UsedRange.Columns.Count;
        int currentRowBeingExamined = FIRST_DESCRIPTION_ROW;
    
        while (currentRowBeingExamined < rowsUsed) 
        {
            Range descriptionCell = _xlPivotTableSheet.Cells[currentRowBeingExamined, DESCRIPTION_COL];
            String desc = descriptionCell.Value2.ToString();
            if (contractItemDescs.Contains(desc))
            {
                Range rangeToColorize = _xlPivotTableSheet.Range[
                    _xlPivotTableSheet.Cells[currentRowBeingExamined, 1],
                    _xlPivotTableSheet.Cells[currentRowBeingExamined + 4, colsUsed]];
                rangeToColorize.Interior.Color = ColorTranslator.ToOle(CONTRACT_ITEM_COLOR);
            }
            currentRowBeingExamined = currentRowBeingExamined + ROWS_BETWEEN_DESCRIPTIONS;
        }
    }
