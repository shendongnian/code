    Project_List objProject_List = new Project_List();
    objProject_List.Proj_Bill_ID = Convert.ToInt32(PID);
    var projList = _OCB.Ins_ProjectTestCycleDet(Convert.ToInt32(PID), TID, RID, ECY,
                   TT, Convert.ToDateTime(GD), Convert.ToDateTime(SD), Convert.ToDateTime(EED), Convert.ToDateTime(ED), null
                   , Convert.ToDecimal(TP), Convert.ToDecimal(TE), Convert.ToDecimal(TDA), Convert.ToDecimal(TR), TCR, ST, null);
     
    if(projList != null
       && projList.Count > 0
       && projList.FirstOrDefault() is Project_List)
    {
        objProject_List = projList.FirstOrDefault();
    }
