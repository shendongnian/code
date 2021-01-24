    using (var contex = new BookingSystemDBEntities())
    {
       context.Configuration.LazyLoadingEnabled = false;
       hallsList = db.tblHalls.ToList();
    }
