    public class BaseFooController<TFoo> : Controller
        where TFoo : Foo, new()
    {
        // all your actions here, utilizing generic type, e.g.:
        [HttpPost]
        public ActionResult Create(TFoo foo)
        {
            ...
        }
    }
    [Authorize(Roles = "normal")]
    public class FooController : BaseFooController<Foo>
    {
    }
    [Authorize(Roles = "admin")]
    public class ExtraFooController : BaseFooController<ExtraFoo>
    {
    }
