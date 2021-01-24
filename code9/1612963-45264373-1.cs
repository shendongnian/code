    var tableA = TableList.FirstOrDefault(t => t.TableName == "a");
    if (tableA != null)
    {
        tableA.DoStuff();
    }
    else
    {
        TableList.FirstOrDefault(t => t.TableName == "f").DoStuff();
    }
