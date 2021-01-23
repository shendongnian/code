    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlite($@"Data Source={dbPath}\sqlite\.sample.sqlite");
                    Batteries.Init();
                    base.OnConfiguring(optionsBuilder);
                }
            }
