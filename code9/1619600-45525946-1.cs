    public abstract class MyBaseApiController : ApiController
    {
        public virtual IHttpActionResult MyReuseMethod(MyDto model)
        {
            return Ok();
        }
    }
    public class MyApiController : MyBaseApiController
    {
        IMyService service;
        public MyApiController()
        {
            service = new MyService();
        }
        public IHttpActionResult Get(int id)
        {
            var dto = service.GetItem(id);
            return MyReuseMethod(dto);
        }
    }
