    public class TicksToDateTimeConverter: ITypeConverter<long, DateTime> {
        public DateTime Convert(long source, DateTime destination, ResolutionContext context) {
            return new DateTime(source); // interpret long as Ticks
        }
    }
    CreateMap<long, DateTime>().ConvertUsing<TicksToDateTimeConverter>();
