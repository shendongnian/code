    PHSRP_DashboardDataModel _DBC = null;
    DbContext _PDBC = null;
    Boolean existingContext;
    if (GetDbContextFromEntity(ActiveWorkSession)!=null)    // is ActiveWorkSession still attached to a Dbcontext ?
    {
        _PDBC = GetDbContextFromEntity(ActiveWorkSession);        //  Get that Context
        existingContext = true;
    }
    else
    {
        _DBC = new PHSRP_DashboardDataModel();             // Open new Context and attach
        _DBC.EmployeeWorkSessions.Attach(ActiveWorkSession);
        existingContext = false;
    }
    switch (lPunch.Type)
    {
         case PunchType.OutForShift:
         {
            // Remove END punch, set SessionEnd time to null 
            try
            {
                WorkEndRecord wsr = ActiveWorkSession.WorkEndRecords.First();
                if (existingContext)
                {
                    ActiveWorkSession.WorkEndRecords.Remove(wsr);
                    ActiveWorkSession.WorkEndDateTime_Actual = null;
                    _PDBC.SaveChanges();
                }
                else
                {
                   _DBC.WorkEndRecords.Remove(wsr);
                   ActiveWorkSession.WorkEndDateTime_Actual = null;
                  _DBC.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                 //  handle exception
            }
            tcUser.UpdateClockState();
            UpdateClockView();
            break;
         }
             |
             |
         Other cases
             |
             |
    }
