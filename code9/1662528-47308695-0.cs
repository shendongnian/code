    public class MyModel {
        public int MyIntProperty { get; set; }
        public string MyStringProperty { get; set; }
    }
    public interface IClientProxy {
        Task<T> Get<T>(string uri);
    }
    public class MyController : Controller {
        IClientProxy _proxy;
        public MyController(IClientProxy _proxy) {
            this._proxy = _proxy;
        }
        public async Task<ActionResult> Index() {
            var categories = await _proxy.Get<MyModel>("/category/get");
            return View(categories);
        }
    }
