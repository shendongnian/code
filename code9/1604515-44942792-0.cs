    var dt = new DataTable();
    dt.Columns.Add("IdColumn", typeof(int));
    for (int i = 0; i < 10; i++)
    {
        dt.Rows.Add(new object[] { i } );
    }
    var del = 3;
    for (int i = 0; i < del; i++)
    {
        dt.Rows[i].Delete();
        dt.AcceptChanges();
        Console.WriteLine("Deleted row number {0}, rows remaining in table are {1}, IdColumn for Rows[i] is {2}", i, dt.Rows.Count, dt.Rows[i]["IdColumn"]);
    }
    Console.WriteLine("\n************************************\n");
