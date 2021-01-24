    public string GetMergedRange(ExcelWorksheet worksheet, string cellAddress)
        {
            ExcelWorksheet.MergeCellsCollection mergedCells = worksheet.MergedCells;
            foreach (var merged in mergedCells)
            {
                if (merged.Contains(cellAddress))
                {
                    return merged.ToString();
                }
            }
            return "";
        }
