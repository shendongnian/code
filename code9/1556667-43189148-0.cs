    TestClass[] items =
    {
        new TestClass{name = "Hans", age = 10 },
        new TestClass{name = "Bert", age = 5 },
        new TestClass{name = "Gerda", age = 41 },
        new TestClass{name = "Dolf", age = 73 },
        new TestClass{name = "Ludo", age = 35 },
    };
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Name", typeof(string));
    dataTable.Columns.Add("Age", typeof(int));
    dataTable.Columns.Add("TestItem", typeof(TestClass));
    // set up the DataTable first
    foreach (var item in items)
    {
        dataTable.Rows.Add(item.name, item.age, item);
    }
    // then use the DataView
    DataView dataView = new DataView(dataTable);
    dataView.RowFilter = "[Name] = 'Hans'";
    comboBox1.DisplayMember = "Name";
    comboBox1.ValueMember = "TestItem";
    comboBox1.DataSource = dataView;
