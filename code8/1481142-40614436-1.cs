    DataTable myTable = new DataTable("myTable");
    DataColumn[] key = new DataColumn[4];
    key[0] = new DataColumn("Company", typeof(string));
    key[1] = new DataColumn("State", typeof(string));
    key[2] = new DataColumn("Type", typeof(string));
    key[3] = new DataColumn("Number", typeof(int));
    myTable.Add(key[0]);
    myTable.Add(key[1]);
    myTable.Add(key[2]);
    myTable.Add(key[3]);
    myTable.Add(new DataColumn("Column6", typeof(string)));
    myTable.Add(new DataColumn("Column7", typeof(string)));
    myTable.Add(new DataColumn("Column8", typeof(string)));
    myTable.Add(new DataColumn("Column9", typeof(string)));
    myTable.Add(new DataColumn("Column10", typeof(string)));
    myTable.PrimaryKey = key;
    
