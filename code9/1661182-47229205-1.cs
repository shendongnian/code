    internal static class EntityTypeBuilderExtensions
    {
        private const Default_Name_MaxLength = 40;
        static public T SetupPropertyName<T>(this T input) where T : EntityTypeBuilder 
        {
            return input
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(Default_Name_MaxLength);
        }
    }
