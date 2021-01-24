    public interface IApplicationDbContext : IDisposable {
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<CarModel> Cars { get; set; }
        int SaveChanges();
        void MarkAsModified(CarModel car);
    }
