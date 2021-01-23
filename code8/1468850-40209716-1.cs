    Random Rnd = new Random();
    List<PayoffNode> PayLL = Enumerable.Range(1, 10).Select(i => new PayoffNode {
        DealNo = i,
        Category = "Account==" + i,
        Data = Enumerable.Range(1, 21).Select(d => (double)Rnd.Next(10, 99)).ToArray()
    }).ToList();
    // List<PayoffNode> to DataTable
    var dt = new DataTable();
    dt.Columns.Add("DealNo", typeof(int));
    dt.Columns.Add("Category"); // typeof(string) by default
    for (int i = 1; i <= 21; i++)
        dt.Columns.Add("Data" + i, typeof(double));
    foreach (var P in PayLL)
    {
        var dr = dt.Rows.Add(P.DealNo, P.Category);
        for (int i = 0; i < 21; i++)
            dr[i+2] = P.Data[i]; // +2 is the number of fields before the Data fields
    }
    PayoffTable.DataSource = dt;
    dt.DefaultView.RowFilter = " Category = 'Account==4' ";
