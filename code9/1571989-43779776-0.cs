    {
        public class BruceDBContext : DbContext
        {
            public BruceDBContext() : base("name=defaultConnectionString")
            {
                this.Database.CommandTimeout = 300;
            }
            public virtual DbSet<Company> Companies { get; set; }
        }
        public class BruceInitializer : DropCreateDatabaseAlways<BruceDBContext>
        {
            protected override void Seed(BruceDBContext context)
            {
                var companies = new List<Company>
                {
                    new Company { Name = "AAA", City = "Eindhoven", Streetname="Street 12" },
                    new Company { Name = "BBB", City = "Rotterdam", Streetname = "Street 12" },
                    new Company { Name = "CCC", City = "Eindhoven", Streetname = "Street 12" },
                    new Company { Name = "EEE", City = "Eindhoven", Streetname = "Street 12" }
                };
                companies.ForEach(s => context.Companies.Add(s));
                context.SaveChanges();
                base.Seed(context);
            }
        }
        [Table("Company")]
        public class Company
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long ID { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string Streetname { get; set; }
        }
    }
