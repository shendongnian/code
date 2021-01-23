        public class SampleDbContext : DbContext
        {
            public SampleDbContext()
                : base("name=SampleDBConnection")
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
          
            public DbSet<NavigationMenu> MaineMenu { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Candidate>().HasMany(t => t.SkillSets).WithMany(t => t.Candidates)
                    .Map(m =>
                    {
                        m.ToTable("candidate_skillset");
                        m.MapLeftKey("candidate_id");
                        m.MapRightKey("skillset_id");
                    });
                modelBuilder.Entity<SkillSet>().ToTable("skillset");
                modelBuilder.Entity<Candidate>().ToTable("candidate");
                modelBuilder.Entity<NavigationMenu>().HasMany(c => c.MenuChildren);
            }
        }
        public class NavigationMenu
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public NavigationMenu()
            {
                MenuChildren = new Collection<NavigationMenu>();
            }
            public string Text { get; set; }
            public string Action { get; set; }
            public string Controller { get; set; }
            public string Icon { get; set; }
            public bool Selected { get; set; }
            
            public ICollection<NavigationMenu> MenuChildren { get; set; }
        }
