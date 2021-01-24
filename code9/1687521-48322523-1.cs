    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableA>()
            .HasRequired<TableB>(p => p.ItemA)
            .WithMany(pp => pp.TableItemAList)
            //.HasForeignKey(x => x.TableBRefAId)
            .WillCascadeOnDelete(false);
        modelBuilder.Entity<TableA>()
            .HasRequired<TableB>(p => p.ItemB)
            .WithMany(pp => pp.TableItemBList)
            //.HasForeignKey(x => x.TableBRefBId)
            .WillCascadeOnDelete(false);
    }
