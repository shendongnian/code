    public class CustomResolver : IValueResolver<Source, Destination, int>
    {
        public int Resolve(Entity entity
            , DTO dto
            , ICollection<FooBar> fooBars
            , ResolutionContext context)
        {
            // Here you should convert from entity Foos and Bars
            // to ICollection<FooBar> and concat them.
        }
    }
