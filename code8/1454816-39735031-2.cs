    public class DemoController : Controller
    {
        [HttpGet]
        public ActionResult Demo()
        {
            var demoList = GetListOfDemoClass().ToList();
            return View(demoList);
        }
        [HttpPost]
        public ActionResult Demo([Bind(Include = "Name,Inuse")]DemoClass demoC)
        {
            var demoList = (from db in GetListOfDemoClass()
                            where (demoC.Name == null || db.Name.Contains(demoC.Name))
                                && db.InUse.Equals(demoC.InUse)
                            select db).ToList();
            return View(demoList);
        }
        private IEnumerable<DemoClass> GetListOfDemoClass()
        {
            yield return new DemoClass() { InUse = false, Name = "Thing 1" };
            yield return new DemoClass() { InUse = true, Name = "Dog 2" };
            yield return new DemoClass() { InUse = false, Name = "Place 3" };
            yield return new DemoClass() { InUse = true, Name = "Raptor 4" };
            yield return new DemoClass() { InUse = false, Name = "Person 5" };
            yield return new DemoClass() { InUse = true, Name = "Hateful 6" };
            yield return new DemoClass() { InUse = false, Name = "Cat 7" };
            yield return new DemoClass() { InUse = true, Name = "Mango 8" };
            yield return new DemoClass() { InUse = false, Name = "Bird 9" };
            yield return new DemoClass() { InUse = true, Name = "Caller 10" };
        }
    }
