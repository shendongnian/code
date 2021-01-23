    public class ValuesController : ApiController
    {
       [CacheWebApi(Duration = 3600)]
        public int Get(int id)
          {
            return new Random().Next();
          }
    }
