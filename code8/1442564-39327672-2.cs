    public class ValuesController : ApiController
    {
       [CacheWebApi(Duration = 20)]
        public int Get(int id)
          {
            return new Random().Next();
          }
    }
