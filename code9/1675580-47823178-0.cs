    modelBuilder.Entity<Laptop>().HasRequired<Electronic>(c => c.Electronic).WithMany(c => c.Laptops).HasForeignKey<int>(c => c.ElectronicID).WillCascadeOnDelete(false);
                modelBuilder.Entity<PC>().HasRequired<Electronic>(c => c.Electronic).WithMany(c => c.PCs).HasForeignKey<int>(c => c.ElectronicID).WillCascadeOnDelete(false);
                modelBuilder.Entity<PCParts>().HasRequired<Electronic>(c => c.Electronic).WithMany(c => c.PCParts).HasForeignKey<int>(c => c.ElectronicID).WillCascadeOnDelete(false);
                modelBuilder.Entity<Network>().HasRequired<Electronic>(c => c.Electronic).WithMany(c => c.Networks).HasForeignKey<int>(c => c.ElectronicID).WillCascadeOnDelete(false);
    
                modelBuilder.Entity<Cooler>().HasRequired<PCParts>(c => c.PCParts).WithMany(c => c.Coolers).HasForeignKey<int>(c => c.PCPartsID);
                modelBuilder.Entity<DiscType>().HasRequired<PCParts>(c => c.PCParts).WithMany(c => c.DiscTypes).HasForeignKey<int>(c => c.PCPartsID);
                modelBuilder.Entity<SoundCard>().HasRequired<PCParts>(c => c.PCParts).WithMany(c => c.SoundCards).HasForeignKey<int>(c => c.PCPartsID);
