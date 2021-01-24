    public static class RepositoryFactory
    {
        public static IGenericRepository<T> MakeRepository<T>(DbContext context) 
            where T : class
        {
            var type = typeof(T);
            
            if (type == typeof(Car))
            {
                return CarRepositoryFactory.CreateCarRpository(context);
            }
            else if (type == typeof(Boat))
            {
                return BoatRepositoryFactory.CreateBoatRepository(context);
            }
        }
    }
