    public class MyController : Controller
    {
        [HttpPost]
        [EncryptedParameter]
        public JsonResult MyMethod(MyObject data)
        {
            // your logic here
        }
    }
