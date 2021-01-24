    public class MyAuthenticatedController : Controller
    {
		public ActionResult Index([FromUri]MyAuthenticatedModel model)
        {
            logTheResponse(model);
            if (model == null)
            {
                throw new HttpException(401, "Auth Failed");
            }
        }
    }
