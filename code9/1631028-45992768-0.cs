    Mapper.Initialize(cfg => {
          cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
          cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
          cfg.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();
          cfg.CreateMap<Source, Destination>();
        });
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }
