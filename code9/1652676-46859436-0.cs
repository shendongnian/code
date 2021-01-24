    public class DbInitializer
    {
        public static void Initialize(PlataformaContext context)
        {
            context.Database.EnsureCreated();
    
            if (!context.MachineTypes.Any())
            {
                var familias = new MachineFamily[] { ... };
                // No need for foreach, AddRange does it for you
                context.MachineFamilies.AddRange(familias);
            }
    
            if (!context.SomeOtherTypes.Any())
            {
                var someOtherType = new SomeOtherType[] { ... };
                context.SomeOtherTypes.AddRange(someOtherType );
            }
            context.SaveChanges();
         }
     }
