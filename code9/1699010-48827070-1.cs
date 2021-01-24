    public static void UpdateCars(int personId, int[] carIds)
    {
        using (var db = new PersonCarDbContext())
        {
            db.PersonCars.UpdateLinks(pc => pc.PersonId, personId, pc => pc.CarId, carIds);
            db.SaveChanges();
        }
    }
