    Public Sub GetColors()
        Dim ewsTarget As Worksheet: Set ewsTarget = ActiveWorkbook.Worksheets(1)
        ewsTarget.Copy , ewsTarget.Parent.Worksheets(ewsTarget.Parent.Worksheets.Count)
        Dim ewsCopy As Worksheet: Set ewsCopy = ewsTarget.Parent.Worksheets(ewsTarget.Parent.Worksheets.Count)
        ewsCopy.UsedRange.ClearContents
        ewsCopy.UsedRange.Columns.EntireColumn.ColumnWidth = 0.5
        ewsCopy.UsedRange.Rows.EntireRow.RowHeight = 5#
        ewsCopy.UsedRange.CopyPicture xlScreen, xlBitmap
        ewsCopy.Delete
    End Sub
