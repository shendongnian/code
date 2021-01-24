    public TimeWorkMonthly Get(int id)
    {
        using (EmployeeDbEntities Entities = new EmployeeDbEntities())
            {
               
                var result = from x in Entities.TimeWorkMonthlies
                                     Where x.KartNo == id
                                     Select x;
                                     
                return result.ToList();
            }
    }
