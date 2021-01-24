    public Test()
    {
        InitializeComponent();
        DataTable smallerDatatable = new DataTable();
        smallerDatatable.Columns.Add("Col1", typeof(int));
        smallerDatatable.Columns.Add("Col2", typeof(string));
        DataTable biggerDatatable = new DataTable();
        biggerDatatable.Columns.Add("Col1", typeof(int));
        biggerDatatable.Columns.Add("Col2", typeof(string));
        smallerDatatable.Rows.Add(1, "Row1");
        smallerDatatable.Rows.Add(2, "Row2");
        smallerDatatable.Rows.Add(3, "Row3");
        biggerDatatable.Rows.Add(1, "Row1");
        biggerDatatable.Rows.Add(2, "Row2");
        biggerDatatable.Rows.Add(3, "Row3");
        biggerDatatable.Rows.Add(4, "Row4");
        biggerDatatable.Rows.Add(5, "Row5");
        DataTable mergedTable = MergeOnUniqueColumn(smallerDatatable, biggerDatatable, "Col1");
        dataGridView1.DataSource = mergedTable;
    }
    private DataTable MergeOnUniqueColumn(DataTable smallTable, DataTable bigTable, string uniqueColumn)
    {
        DataTable m = smallTable;
        for(int i = 0; i < bigTable.Rows.Count; i++)
        {
            if(!(smallTable.AsEnumerable().Any(row => bigTable.Rows[i][uniqueColumn].Equals(row.Field<object>(uniqueColumn)))))
            {
                smallTable.Rows.Add(bigTable.Rows[i].ItemArray);
            }
        }
        return m;
    }
