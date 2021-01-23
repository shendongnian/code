    dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
    dataGridView1.RowHeadersVisible = false;  // the row headers column is copied too if visible
    dataGridView1.SelectAll();                // only the selected cells are used (the Windows Clipboard is not used)
    DataObject dataObject = dataGridView1.GetClipboardContent();      // 4 Data Formats: Text,Csv,HTML Format,UnicodeText
    File.WriteAllText("1.csv", dataObject.GetData("Csv") as string);  // DataFormats.CommaSeparatedValue = "Csv"
    //string html = Encoding.ASCII.GetString((dataObject.GetData("HTML Format") as MemoryStream).ToArray()); // just the HTML Clipboard Format is in a MemoryStream
