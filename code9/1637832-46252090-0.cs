    bool exisingCompanyFlag = false;
    TimeTable c = (from x in db.TimeTables
                   where x.Company == timeTable.Company && x.INN == timeTable.INN
                         select x).FirstOrDefult();
    
    if (c == null)
      exisingCompanyFlag = true;
    
    c.StartPause = timeTable.StartPause;
    c.StartDay = timeTable.StartDay;
    c.EndPause = timeTable.EndPause;
    c.EndDay = timeTable.EndDay;
    if (!exisingCompanyFlag)
       db.TimeTables.Add(c);
