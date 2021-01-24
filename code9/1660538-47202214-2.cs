    try 
    {
        var db1 = new DataBase1Entities();
        try 
        {
            var db2 = new DataBase2Entities()
            // do something with db2
        }
        finally 
        {
            if(db2 != null) db2.Dispose(); }
        }
    }
    finally
    {
        if(db1 != null) db1.Dispose();
    }
 
