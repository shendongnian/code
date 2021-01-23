    DataTable table = new DataTable();
    table.Columns.Add("Date", typeof(DateTime));
    table.Columns.Add("Item Name", typeof(string));
    table.Columns.Add("Buyer", typeof(string));
    table.Columns.Add("Quantity", typeof(int));
    table.Columns.Add("Price", typeof(decimal));
    string[] fields = {"12/12/2013","test","Hello","3","345.45"};
    table.Rows.Add(fields[0], fields[1], fields[2], fields[3], fields[4]);
