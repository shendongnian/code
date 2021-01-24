    private Boolean SessionClockOut(DateTime timeOUT)
    {
        Boolean success = false;
        Boolean abort = false;
        tcPunch newPunch = new tcPunch();
     // Added 'using' statement
        using (PHSRP_DashboardDataModel _DBC = new PHSRP_DashboardDataModel())
        {
            while (!success && !abort)
            {
                var wsUpdate = _DBC.EmployeeWorkSessions
                                   .Where(w => (w.EmployeeWorkSessionID == ActiveWorkSession.EmployeeWorkSessionID))
                                   .Include(w => w.WorkStartRecords)
                                   .Include(w => w.WorkEndRecords)
                                   .Include(w => w.WorkSessionBreaks)
                                   .FirstOrDefault();
                if (wsUpdate != null)
                {
                    WorkEndRecord er = new WorkEndRecord();
                    try
                    {
                        wsUpdate.WorkEndDateTime_Actual = timeOUT;
                        er.EmployeeWorkSessionID = ActiveWorkSession.EmployeeWorkSessionID;
                        er.EditTimeStamp = DateTime.Now;
                        er.WorkEndDateTime_Official = timeOUT;
                        er.VarianceReasonID = VarianceReason.VR_None;
                        er.EditByID = ActiveWorkSession.EmployeeID;
                        wsUpdate.WorkEndRecords.Add(er);
                        _DBC.SaveChanges();
                        ActiveWorkSession = wsUpdate;
                        tcUser.UpdateClockState();
                            UpdateClockView();
            //  Tried this before adding the using statement. It also worked.
            //          _DBC.Entry(ActiveWorkSession).State = EntityState.Detached;         // Release from DB Context
                        PreviousWorkSession = ActiveWorkSession;                            // needed For Undo Punch 
                        ActiveWorkSession = null;                                           // Worksession has ended
                        success = true;
                    }
                    catch (DbUpdateException e)
                    {
                       //  handle exception...
                        abort = true;
                        throw;
                    }
                    newPunch.EmployeeID = wsUpdate.EmployeeID;
                    newPunch.WorksessionID = wsUpdate.EmployeeWorkSessionID;
                    newPunch.Type = PunchType.OutForShift;
                    newPunch.TimeStamp = er.EditTimeStamp;
                    if (tcUser.hasPriv(PrivilegeTokenValue.TC_UndoRecentPunch)) tcLastPunchUndo.StartUndoTimer(newPunch);
                }  // if
            }  //  while 
        }  // using
        return success;
    }
