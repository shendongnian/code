    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    var files = System.IO.Directory.GetFiles(desktopPath, "*.txt")
                                    .Select(x => System.IO.Path.GetFileName(x)).ToArray();
    comboBox1.Items.AddRange(files);
    comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
