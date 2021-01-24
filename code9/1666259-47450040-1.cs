    <!-- begin snippet: js hide: false console: true babel: false -->
    DataTable dt = new DataTable();
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Type", typeof(string));
    dt.Columns.Add("Amount", typeof(decimal));
    dt.Rows.Add(new object[] {
        "John",
        "A",
        1.23
    });
    dt.Rows.Add(new object[] {
        "Harry",
        "B",
        4.56
    });
    dt.Rows.Add(new object[] {
        "Dick",
        "C",
        7.89
    });
    dt.Rows.Add(new object[] {
        "Mary",
        "B",
        6.54
    });
    dt.Rows.Add(new object[] {
        "Pat",
        "D",
        1.23
    });
    dt.Rows.Add(new object[] {
        "Dana",
        "A",
        8.76
    });
    dt.Rows.Add(new object[] {
        "Rob",
        "C",
        9.65
    });
    var groups = dt.AsEnumerable().GroupBy(x => x.Field < string > ("Type")).ToList();
    DataTable summary = new DataTable();
    summary.Columns.Add("Type", typeof(string));
    summary.Columns.Add("Amount", typeof(decimal));
    foreach(var group in groups) {
        DataRow newRow = summary.Rows.Add();
        newRow["Type"] = group.Key;
        newRow["Amount"] = group.Select(x => x.Field <decimal > ("Amount")).Sum();
    }
    <!-- end snippet -->
