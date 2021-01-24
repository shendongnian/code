    modelBuilder.Entity<Device>()
                .HasKey(it => it.Id);
    modelBuilder.Entity<RTUDevice>()
                .HasKey(it => it.Id);
    modelBuilder.Entity<Device>()
                .HasOptional(it => it.RTUDevice)
                .WithRequired(it => it.Device);
