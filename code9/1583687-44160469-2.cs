    using (iDataContext db = new iDataContext(connectionString))
    {
         var statusList = from s in db.Set<student>()
                          select s;
         if (!String.IsNullOrEmpty(name))
         {
              statusList = statusList.Where(s => s.studentname.Contains(name));
         }
         if (!String.IsNullOrEmpty(city))
         {
              studentList = studentList.Where(s => s.studentcity.Contains(city));
         }
         if (!String.IsNullOrEmpty(state))
         {
             studentList = studentList.Where(s => s.studentstate.Contains(state));
         }
         return statusList.ToList();
    }
