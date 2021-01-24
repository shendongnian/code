    [Given(@"...")]
    public void GivenNumList(Table table)
    {
        DataTable dataTable = table.ToDataTable<int>();
        // dataTable.Rows[0]["num"] is an int
    }
