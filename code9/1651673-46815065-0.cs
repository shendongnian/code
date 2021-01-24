    public static decimal accountDefinitiveID { get; set; }
     
    public static void GetDefinitiveID(decimal LedgerID)
    {
        var query = database.Database.SqlQuery<tbl_AccountDefinitive>("Select Top(1) *From tbl_AccountDefinitive Where LedgerID='" + LedgerID + "' Order By DefinitiveID DESC");
        var result = query.ToList();
        if (result.Count == 1)
        {
            accountDefinitiveID = result[0].DefinitiveID + 1;
        }
        else
        {
            accountDefinitiveID = Convert.ToInt32(LedgerID) * 100 + 1;
        }
    }
