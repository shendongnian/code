    using Microsoft.SqlServer.Management.Smo;
    ....
    Server svr = new Server("Your Server Name");
    Database db = svr.Databases["Your Database Name"];
    Table tbl = db.Tables["DeliveryData"];
    foreach (Column c in tbl.Columns)
    {
        bool isAKeyColumn = c.InPrimaryKey
                
    }
