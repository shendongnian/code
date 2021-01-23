    public class ValuesController : ApiController
    {
       [CacheOutput(ClientTimeSpan = 3600, ServerTimeSpan = 3600)]
        public int Get(int id)
          {
            return new Random().Next();
          }
    }
