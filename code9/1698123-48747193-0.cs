    private void CopyLastRowToAnotherGrid()
    {
        GridControl source = /* your first grid */;
        GridControl target = /* your second grid */;
        if (source.VisibleRowCount < 1)
            return;
        var handle = source.GetRowHandleByVisibleIndex(source.VisibleRowCount - 1);
        // You can set ClipboardCopyMode in Xaml.  The point is, we want the
        // headers to be included so we can match the cells up in case the
        // user has reordered them.
        source.ClipboardCopyMode = ClipboardCopyMode.IncludeHeader;
        source.CopyRowsToClipboard(new[] { handle });
        var clipboardData = Clipboard.GetDataObject();
        var data = clipboardData?.GetData(DataFormats.Text) as string;
        if (data == null)
            return;
        var targetView = target.View as TableView;
        if (targetView == null)
            return;
        targetView.AddNewRow();
        if (!target.IsValidRowHandle(DataControlBase.NewItemRowHandle))
            return;
        var headersAndRows = data.Split('\n');
        var headers = headersAndRows[0].Split('\t');
        var columnValues = headersAndRows[1].Split('\t');
        var columnLookup = target.Columns.ToDictionary(o => o.HeaderCaption?.ToString());
        for (var i = 0; i < headers.Length; i++)
        {
            var header = headers[i];
            if (columnLookup.TryGetValue(header, out var column))
                target.SetCellValue(DataControlBase.NewItemRowHandle, column, columnValues[i]);
        }
    }
