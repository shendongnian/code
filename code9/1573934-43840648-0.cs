    private static void RenameSubCategory(ExcelWorksheet sheet, string subCategoryOld, string subCategoryNew)
    {
        foreach (ExcelRow row in sheet.Rows)
            foreach (ExcelCell cell in row.AllocatedCells)
                if (cell.ValueType == CellValueType.String &&
                    cell.StringValue.Contains(subCategoryOld))
                    cell.Value = subCategoryNew;
    }
