    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalPrecision : Attribute
    {
        public byte precision { get; set; }
        public byte scale { get; set; }
        public DecimalPrecision(byte precision, byte scale)
        {
            this.precision = precision;
            this.scale = scale;
        }
        public static void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<DecimalPrecision>().Any())
                .Configure(c => c.HasPrecision(c.ClrPropertyInfo.GetCustomAttributes(false).OfType<DecimalPrecision>().First()
                    .precision, c.ClrPropertyInfo.GetCustomAttributes(false).OfType<DecimalPrecision>().First().scale));
        }
    }
