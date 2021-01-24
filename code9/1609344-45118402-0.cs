    DataTable table = new DataTable();
    table.Columns.Add("ID");
    table.Columns.Add("Name");
    table.Columns.Add("Surname");
    table.Rows.Add("1", "Mike","Zt");
    table.Rows.Add("2", "Richard", "Milko");
    table.Rows.Add("3", "Sumo", "Sansimo");
    DataTable newTable = table.DefaultView.ToTable(false, new string[] {"ID", "Name"});
    foreach(DataRow r in newTable.Rows)
            Console.WriteLine("ID=" + r.Field<string>("ID") + ", Name=" + r.Field<string>("Name"));
