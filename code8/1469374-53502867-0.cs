    services.AddDbContext<DbContext>(o =>
                {
                    o.UseInMemoryDatabase(nameof(DbContext)); //tokens and stuff is stored in memory, not the actual users or passwords. 
                    o.UseOpenIddict();
                });
