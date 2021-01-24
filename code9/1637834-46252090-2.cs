        bool existingCompanyFlag = true;
        TimeTable c = (from x in db.TimeTables
                       where x.Company == timeTable.Company && x.INN == timeTable.INN
                             select x).FirstOrDefult();
        
        if (c == null)
        {
          existingCompanyFlag = false;
          c = new TimeTable();
        }   
        c.StartPause = timeTable.StartPause;
        c.StartDay = timeTable.StartDay;
        c.EndPause = timeTable.EndPause;
        c.EndDay = timeTable.EndDay;
        if (!existingCompanyFlag)
           db.TimeTables.Add(c);
