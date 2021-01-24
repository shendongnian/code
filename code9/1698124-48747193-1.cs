    private void CopyLastRowToAnotherGrid()
    {
        const int targetHandle = DataControlBase.NewItemRowHandle;
        GridControl source = /* your first grid */;
        GridControl target = /* your second grid */;
        if (source.VisibleRowCount < 1|| !target.IsValidRowHandle(targetHandle))
            return;
        var sourceHandle = source.GetRowHandleByVisibleIndex(source.VisibleRowCount - 1);
        // You can set ClipboardCopyMode in Xaml.  The point is, we want the
        // headers to be included so we can match the cells up in case the
        // user has reordered them.
        source.ClipboardCopyMode = ClipboardCopyMode.IncludeHeader;
        source.CopyRowsToClipboard(new[] { sourceHandle });
        var clipboardData = Clipboard.GetDataObject();
        var data = clipboardData?.GetData(DataFormats.Text) as string;
        if (data == null)
            return;
        var targetView = target.View as TableView;
        if (targetView == null)
            return;
        targetView.AddNewRow();
        var headersAndRows = data.Split('\n');
        var headers = headersAndRows[0].Split('\t');
        var columnValues = headersAndRows[1].Split('\t');
        var columnLookup = target.Columns.ToDictionary(o => o.HeaderCaption?.ToString());
        for (var i = 0; i < headers.Length; i++)
        {
            var header = headers[i];
            if (columnLookup.TryGetValue(header, out var column))
                target.SetCellValue(targetHandle, column, columnValues[i]);
        }
        // If you want to *move* the row, then uncomment this line to
        // delete the row from the first grid:
        //(source.View as TableView)?.DeleteRow(sourceHandle);
    }
