    public class RSUConfiguration : EntityTypeConfiguration<RSU>
    {
        public RSUConfiguration()
        {
            Property(x => x.Length)
                .HasPrecision(6, 2);
        }
    }
