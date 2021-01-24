    public TimeWorkMonthly Get(int id)
    {
        using (EmployeeDbEntities Entities = new EmployeeDbEntities())
        {
            var result = Entities.TimeWorkMonthlies.Where(e => e.KartNo == id).Single();
            return result;
        }
    }
