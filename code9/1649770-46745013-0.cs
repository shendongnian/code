                .HasMany(i => i.ApplicationUsers)
                .WithMany(i => i.FileTypes)
                .Map(m => // use map if you're overwriting convention, otherwise sql will create name of the columns automatically
                {
                    m.ToTable("FileTypesAndSmth");
                    m.MapLeftKey("ApplicationUserId");
                    m.MapRightKey("FileTypeId");
                });
