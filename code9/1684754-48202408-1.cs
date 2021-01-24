    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         // Configure entity table FOO:
         var entityFoo = modelBuilder.Entity<Foo>();
         // example: configure Name and primary key of foo table
         entityFoo.ToTable("MySpecialFooTable");
         entifyFoo.HasKey(foo => foo.FooRowId);
         // example: configure property Name is in column FooName:
         entityFoo.Property(foo => foo.Name).HasColumnName("MyFooName");
         // example: one-to-many relation between foo and bar
         // every Foo has zero or more Bars in property MyBars,
         // every Bar belongs to exactly one For in property MyFoo
         // using foreign key MyFooId:
         entityFoo.HasMany(foo => foo.MyBars)         // Foo has zero or more Bars in MyBars
                  .WithRequired(bar => bar.MyFoo)     // every Bar belongs to one Foo
                  .HasForeignKey(bar => bar.MyFooId); // using foreign key MyFooId
    }
