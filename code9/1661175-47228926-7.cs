    class ExtensionMethods
    {
        static public T SetupEntity<T>(this T input) where T : EntityTypeBuilder 
        {
            return input
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
           
     
