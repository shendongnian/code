    public class FooBarConfiguration : IEntityTypeConfiguration<FooBar>
    {
        public void Configure(EntityTypeBuilder<FooBar> builder)
        {
            var fkFoo = "FooId";
            var fkBar = "BarId";
    
            builder.HasKey(fkFoo, fkBar);
            builder
                .HasOne(fb => fb.Foo)
                .WithMany(f => f.FooBars)
                .HasForeignKey(fkFoo);
            builder
                .HasOne(fb => fb.Bar)
                .WithMany(b => b.FooBars)
                .HasForeignKey(fkBar);
        }
    }
