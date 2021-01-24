    public List<Car> SearchCar(DateTime pickdate, DateTime dropdate)
    {
       using (var db = new CarRentalDBEntities())
       {
           return db.Cars.Where(item => item.Orders.All(e =>
                   // where order pickup date is less Pick or greater than drop
               (e.PickUpDateTime < pickdate || e.PickUpDateTime > dropdate) &&
                   // where order Drop date is less Pick or greater than drop
               (e.DropDataTime < pickdate || e.DropDataTime > dropdate)))
                   .ToList();
       }
    }
