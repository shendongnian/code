      modelBuilder.Entity<UserDeviceFeatureStatus>()
            .HasKey(t => new { t.UserDeviceID, t.DeviceFeatureID });
        modelBuilder.Entity<UserDeviceFeatureStatus>()
            .HasOne(pt => pt.UserDevice)
            .WithMany(p => p.DeviceFeatures) // from UserDevice
            .HasForeignKey(pt => pt.UserDeviceID);
        modelBuilder.Entity<UserDeviceFeatureStatus>()
            .HasOne(pt => pt.DeviceFeature)
            .WithMany(t => t.UserDevices) //from DeviceFeature
            .HasForeignKey(pt => pt.DeviceFeatureID);
