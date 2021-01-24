    public class EntityController : APIController
    {
        [Route("Get")]
        public HttpResponseMessage Get([ModelBinder(typeof(DicModelBinder))]Dictionary<string, string> dic)
        { ... }
    }
