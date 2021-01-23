    Server srv = new Server("(local)");
    Database db = srv.Databases["AdventureWorks2012"];
    
    Table tb = new Table(db, "Test Table");
    Column col1 = new Column(tb, "Name", DataType.NChar(50));
    Column col2 = new Column(tb, "ID", DataType.Int);
    
    tb.Columns.Add(col1); 
    tb.Columns.Add(col2); 
    tb.Create();
