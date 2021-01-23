    internal class ChildConfig<T> : EntityTypeConfiguration<T> where T : Child
    {
        public ChildConfig(...)
        {
            // configure all Child properties
            this.Property(p => p.Name)....
        }
    }
    internal class BoyConfig : ChildConfig<Boy>
    {
        public BoyConfig(...) : base (...)
        {
            // the base class will configure the Child properties
            // configure the Boy properties here
            this.Property(p => p.SomeBoyishProperty)...
        }
    }
