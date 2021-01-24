    var progress = new Progress<int>(progressPercent => pBar.Value = progressPercent);
    var result = await Task.Run(() => _sourceService.ReadFileContent(filePath, progress));
    dataGrid.ItemsSource = result.DefaultView;
    DataTable = result;
    if (DataTable.Rows.Count > 0)
      BtnCreateXmlFile.IsEnabled = true;
