    using (iDataContext db = new iDataContext(connectionString))
    {
         var statusList = from s in db.Set<student>()
                          select s;
         if (!String.IsNullOrEmpty(name))
         {
              statusList = statusList.Where(s => s.studentname == name);
         }
         if (!String.IsNullOrEmpty(city))
         {
              studentList = studentList.Where(s => s.studentcity == city);
         }
         if (!String.IsNullOrEmpty(state))
         {
             studentList = studentList.Where(s => s.studentstate == state);
         }
         return statusList.ToList();
    }
