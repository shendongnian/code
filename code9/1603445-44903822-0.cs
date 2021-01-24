    [WebMethod]
    public static string GetCnorGSTNo(string Param1)
    {
        DataAccess clsObjDataAccess = new DataAccess();
        string qrySelCnorGtinNo = "select TinNo1 from CnorMaster where CnorName = '" + Param1 + "'";
        return clsObjDataAccess.GetDataTable(qrySelCnorGtinNo).AsEnumerable()
           .ElementAtOrDefault(0)?.Field<string>("TinNo1");
    }
