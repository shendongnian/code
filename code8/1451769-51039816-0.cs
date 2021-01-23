    public class ValuesController : ApiController
    {
        public object Get(DateTimeOffset dt)
        {
            return new {
                Input = dt,
                Local = dt.LocalDateTime,
                Utc = dt.UtcDateTime
            };
        }
    }
