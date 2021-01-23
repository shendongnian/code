     DataTable checkedData = new DataTable();
            checkedData.Columns.AddRange(new DataColumn[6] { new DataColumn("CampCode"), new DataColumn("BalUnits", typeof(decimal)), new DataColumn("ExitUni",typeof(decimal)), new DataColumn("itemNum"), new DataColumn("UOM"), new DataColumn("WT", typeof(decimal)) });
    
    dr["CampCode"]=lblexitUnits.text;
    //And so on
    DataRow dr = checkedData.NewRow();
