    public abstract class ReplaceableConfiguration<T> : EntityTypeConfiguration<T>
        where T : Replaceable
    {
        public ReplaceableConfiguration()
        {
            this.Property(r => r.Replacing).HasColumnName(typeof(T).Name + "_ID");
        }
    }
