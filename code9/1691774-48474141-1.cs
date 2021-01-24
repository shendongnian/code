    public class WeatherAppDbEntities : IdentityDbContext<ApplicationUser>
    {
        public WeatherAppDbEntities()
            : base("DefaultConnection")
        {
        }
    }
