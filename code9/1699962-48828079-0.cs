      foreach(var emp in empList)
      {
         var empLogs = lstMachineInfo.Where(x => x.RegisterationId == int.Parse(emp.EnrollNumber)).ToList();
         var prevDate = (from obj in empLogs select obj.Date).FirstOrDefault();
    
           foreach (var p in empLogs)
            {                   
              if (checkSingle.Count > 0)
              {
                 if (prevDate < p.Date) {
                     inn = true;
                      prevDate = p.Date;
              }
              if (inn)
              {
                inn = false;
                p.CheckType = "I";
              }
              else
              {
               inn = true;
               p.CheckType = "O";
              }
       }
              else
              {
               p.CheckType = "SINGLE DEVICE DEACTIVATED IN PERMISSIONS CHECK";
              }
              db.AttendanceLogs.Add(p);
      }
    }
              db.SaveChanges();
