    public static void UpdatePersons(int carId, int[] personIds)
    {
        using (var db = new PersonCarDbContext())
        {
            db.PersonCars.UpdateLinks(pc => pc.CarId, carId, pc => pc.PersonId, personIds);
            db.SaveChanges();
        }
    }
