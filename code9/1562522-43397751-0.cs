    GlobalConfiguration.Configuration
                       .Formatters
                       .JsonFormatter
                       .SerializerSettings
                       .Converters
                       .Add(new IsoDateTimeConverter
                       {
                           DateTimeStyles = DateTimeStyles.AdjustToUniversal
                       });
