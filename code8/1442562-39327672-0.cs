    public class ValuesController : ApiController
    {
       [CacheOutput(ClientTimeSpan = 1800, ServerTimeSpan = 1800)]
        public int Get(int id)
          {
            return new Random().Next();
          }
    }
