            modelBuilder.Entity<CustomerDevice>()
                .HasKey(c => new { c.CustId, c.DevId });
            modelBuilder.Entity<CustomerDevice>()
                .HasOne(cd => cd.Customer)
                .WithMany(c => c.CustomerDevices)
                .HasForeignKey(cd => cd.CustId);
            modelBuilder.Entity<CustomerDevice>()
                .HasOne(cd => cd.Device)
                .WithMany(d => d.CustomerDevices)
                .HasForeignKey(cd => cd.DevId);
        
