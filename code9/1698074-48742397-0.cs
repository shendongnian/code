        Server1Entities dc1 = new Server1Entities ();
        List<IDTable> ids = (from ro in dc1.IDTable select ro).ToList();
        Server2Entities dc2 = new Server2Entities();
        var list = (from firstTable in ids
                    join secondTable in dc.YourSecondTable
                    on firstTable.ID equals secondTable.ID
                    select new {
                      
                     field1 = firstTable.Field1,
                     field2 = secondTableField1 // You can define fieldnames as you want.
                    }).ToList();
