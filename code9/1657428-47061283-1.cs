    public class DatenbankContext : DbContext
    {
        static DatenbankContext()
        {
            Database.SetInitializer(new CustomDbInitializer());
        }
    }
