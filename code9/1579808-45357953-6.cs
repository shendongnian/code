    public void GivenSomeList(Table table)
    {
        DataTable dataTable = table.ToDateTable<int, string>();
        // use it
    }
