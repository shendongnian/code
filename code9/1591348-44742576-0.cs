    class Program
    {
        static void Main(string[] args)
        {
            var id = 0;
            using (var dbContext = new MyContext())
            {
                var department = new Department();
                department.AddFaculty(FacultyEnum.Eng);
                department.AddFaculty(FacultyEnum.Math);
                dbContext.Department.Add(department);
                var department2 = new Department();
                department2.AddFaculty(FacultyEnum.Math);
                dbContext.Department.Add(department2);
                dbContext.SaveChanges();
                id = department.Id;
            }
            using (var dbContext = new MyContext())
            {
                var department = dbContext.Department.Find(id);
                department.AddFaculty(FacultyEnum.Eco);
                dbContext.SaveChanges();
            }
            using (var dbContext = new MyContext())
            {
                var department = dbContext.Department.Find(id);
                var faculty = department.Faculties.Where(x => x.Id == (int)FacultyEnum.Eng).FirstOrDefault();
                department.Faculties.Remove(faculty);
                dbContext.SaveChanges();
            }
            using (var dbContext = new MyContext())
            {
                var department = dbContext.Department.Find(id);
                Console.WriteLine($"Department Id {department.Id} has these faculties:");
                foreach (var faculty in department.Faculties)
                {
                    Console.WriteLine($"- {faculty.Id}");
                }
            }
            Debugger.Break();
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public MyContext()
            : base(nameOrConnectionString: GetConnectionString())
        {
            Database.SetInitializer(new MyDbInitializer());
        }
        public override int SaveChanges()
        {
            CleanUpFaculties();
            return base.SaveChanges();
        }
        private void CleanUpFaculties()
        {
            var departments = ChangeTracker
                .Entries<Department>()
                .Select(x => x.Entity)
                .ToList();
            var cachedDataToReload = departments
                .Select(department => new
                {
                    Department = department,
                    FacultyIds = department.Faculties.Select(faculty => faculty.Id).ToList(),
                })
                .ToList();
            CleanUpFacultiesOnChangeTracker();
            foreach (var item in cachedDataToReload)
            {
                var faculties = LoadFacultiesFromDb(item.FacultyIds);
                typeof(Department).GetProperty("Faculties")
                    .SetValue(item.Department, faculties);
            }
        }
        private void CleanUpFacultiesOnChangeTracker()
        {
            var changedEntries = ChangeTracker.Entries<Faculty>().Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
        private ICollection<Faculty> LoadFacultiesFromDb(IEnumerable<FacultyEnum> facultyIds)
        {
            var destination = new List<Faculty>();
            foreach (var id in facultyIds)
            {
                var newFaculty = ChangeTracker
                    .Entries<Faculty>()
                    .Where(x => x.State == EntityState.Unchanged && x.Entity.Id == id)
                    .FirstOrDefault()
                    ?.Entity;
                if (newFaculty == null)
                {
                    newFaculty = Set<Faculty>().Find(id) ?? id;
                }
                destination.Add(newFaculty);
            }
            return destination;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new FacultyConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        private static string GetConnectionString()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestEnum;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;";
        }
    }
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            context.Faculty.SeedEnumValues<Faculty, FacultyEnum>(theEnum => theEnum);
            context.SaveChanges();
            base.Seed(context);
        }
    }
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            HasMany(x => x.Faculties)
                .WithMany();
        }
    }
    public class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
        {
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    public class Department
    {
        public int Id { get; set; }
        public virtual ICollection<Faculty> Faculties { get; private set; }
        public Department()
        {
            Faculties = new List<Faculty>();
        }
        public void AddFaculty(FacultyEnum faculty)
        {
            Faculties.Add(faculty);
        }
    }
    public class Faculty
    {
        public FacultyEnum Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private Faculty(FacultyEnum theEnum)
        {
            Id = theEnum;
            Name = theEnum.ToString();
            Description = theEnum.Description();
        }
        protected Faculty() { } //For EF
        public static implicit operator Faculty(FacultyEnum theEnum) => new Faculty(theEnum);
        public static implicit operator FacultyEnum(Faculty faculty) => faculty.Id;
    }
    public enum FacultyEnum
    {
        [Description("English")]
        Eng,
        [Description("Mathematics")]
        Math,
        [Description("Economy")]
        Eco,
    }
    public static class Extensions
    {
        public static string Description<TEnum>(this TEnum item)
            => item.GetType()
                   .GetField(item.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .Cast<DescriptionAttribute>()
                   .FirstOrDefault()?.Description ?? string.Empty;
        public static void SeedEnumValues<T, TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class => Enum.GetValues(typeof(TEnum))
                                   .Cast<object>()
                                   .Select(value => converter((TEnum)value))
                                   .ToList()
                                   .ForEach(instance => dbSet.AddOrUpdate(instance));
    }
