    private static void updateICAT(DataSet s)
    {
        DataTable excelTable = s.Tables[7];
        DataTable contacts = getXML();
        Context _db = new Context();
        Context db2 = new Context();
        var updateICAT = _db.ICATs;
        int counter = 1;
        foreach(ICAT icat in updateICAT)
        {
            if(icat.ICATName != "--NOT AVAILABLE--")
            {
                DataRow r = contacts.Select("ICATName='" + excelTable.Rows[counter].ItemArray[2].ToString().Trim() + "'")[0];
                if (icat.ICATName != excelTable.Rows[counter].ItemArray[0].ToString())
                {
                    System.Diagnostics.Debug.WriteLine("not match");
                    System.Diagnostics.Debug.WriteLine("current Icat id " + icat.ICATID + " current counter " + counter);
                    var updateCurrentICAT = db2.ICATs.SingleOrDefault(p => p.ICATID == counter);
                    updateCurrentICAT.ICATName = excelTable.Rows[counter].ItemArray[0].ToString().Trim();
                    updateCurrentICAT.MEGroup = excelTable.Rows[counter].ItemArray[1].ToString().Trim();
                    updateCurrentICAT.EscalationDisplayName = excelTable.Rows[counter].ItemArray[2].ToString().Trim();
                    updateCurrentICAT.EscalationUserName = r["Username"].ToString().Trim();
                    updateCurrentICAT.EscalationMail = r["Mail"].ToString().Trim();
                }
            }
            counter++;
        }
    }
