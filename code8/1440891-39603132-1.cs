    var filename = @"iris.data.csv";
    var format = new CSVFormat('.', ',');
    IVersatileDataSource source = new CSVDataSource(filename, false, CSVFormat.DecimalPoint);
    var data = new VersatileMLDataSet(source);
    // Define columns to read data in.
    data.DefineSourceColumn("Col1", 0, ColumnType.Continuous);
    data.DefineSourceColumn("Col2", 1, ColumnType.Continuous);
    data.DefineSourceColumn("Col3", 2, ColumnType.Continuous);
    data.DefineSourceColumn("Col4", 3, ColumnType.Continuous);
    ColumnDefinition outputColumn = data.DefineSourceColumn("Col5", 4, ColumnType.Nominal);
    // Analyze data
    data.Analyze();
    // Output mapping
    data.DefineSingleOutputOthersInput(outputColumn);
    // Set normalization strategy
    data.NormHelper.NormStrategy = new BasicNormalizationStrategy(-1, 1, -1, 1);
    data.Normalize();
    // Get count
    var count = data.GetRecordCount();
    // Clone to get original data
    var oiginalData = data.Data.Clone();
