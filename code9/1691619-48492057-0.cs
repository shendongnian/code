    public Contexte()
            {
                if (!_created)
                {
                    _created = true;
                    Database.EnsureDeleted();
                    Database.EnsureCreated();
                }
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
            {
                optionbuilder.UseSqlite(@"Data Source=AideProf.db");
            }
