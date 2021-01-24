        bool exisingCompanyFlag = true;
        TimeTable c = (from x in db.TimeTables
                       where x.Company == timeTable.Company && x.INN == timeTable.INN
                             select x).FirstOrDefult();
        
        if (c == null)
        {
          exisingCompanyFlag = false;
          c = new TimeTable();
        }   
        c.StartPause = timeTable.StartPause;
        c.StartDay = timeTable.StartDay;
        c.EndPause = timeTable.EndPause;
        c.EndDay = timeTable.EndDay;
        if (!exisingCompanyFlag)
           db.TimeTables.Add(c);
