    public class ClassUtilitiesController : ApiController
    {
        [HttpPost]
        public string GetClassNamespace(string data)
        {
            T t;
            try
            {
                t = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                return e;
            }
            return t.FullName;
        }
    }
