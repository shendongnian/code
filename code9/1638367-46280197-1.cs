    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser>, IApplicationDbContext {
        public ApplicationDbContext()
            : base("ApplicationDb", throwIfV1Schema: false) {
        }
        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }
        public virtual IDbSet<CarModel> Cars { get; set; }
        public void MarkAsModified(CarModel car) {
            Entry(car).State = EntityState.Modified;
        }
    }
