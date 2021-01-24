    var assembly = typeof(MainPage).GetTypeInfo().Assembly;
    Stream stream = assembly.GetManifestResourceStream("XFTest.users.csv");
    var csvData = DataTable.New.ReadLazy(stream);
    var rows = csvData.Rows.ToList();
    List<User> users = test.RowsAs<User>().ToList();
