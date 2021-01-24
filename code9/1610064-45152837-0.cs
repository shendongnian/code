        var uspCapacity = from d in db.uspGetEventKillSheetDetailedReport(option, date)
                          select new
                          {
                              d.Capacity
                          };
        var uspAttendance = from d in db.uspGetEventKillSheetDetailedReport(option, date)
                            select new
                            {
                                d.Attendance
                            };
        var uspSectionMapCode = from d in db.uspGetEventKillSheetDetailedReport(option, date)
                            select new
                            {
                                d.SectionMapCode
                            };
    
        var uspCapacityList = uspCapacity.ToArray();
        var uspAttendanceList = uspAttendance.ToArray();
        var uspSectionMapCodeList = uspSectionMapCode.ToArray();
