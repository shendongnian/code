    var phonesDataTable = new DataTable("Phones");
    phonesDataTable.Columns.Add("Phone", typeof(string));
    foreach(var phone in phones) // phones is the values
    {
        phonesDataTable.Rows.Add(phone);
    }
