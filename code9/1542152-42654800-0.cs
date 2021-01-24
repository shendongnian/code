     var tblCost = ds.Tables[1];
     var tblPremises = ds.Tables[0];
     foreach (DataRow cost in tblCost.Rows)
     {
        var premRow = tblPremises.AsEnumerable().Where(row => row.Field<int>("PremNo") == cost.Field<int>("PremNo")).FirstOrDefault();
        if (premRow != null)
            cost["ID"] = premRow.Field<int>("ID");
     }
