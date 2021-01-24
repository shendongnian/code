    interface IMyDataLayer 
    {
        int UploadToDb(SomeModel model);
    }
    class MyDataLayer : IMyDataLayer 
    {
        public int UploadToDb(SomeModel model)
        {
            // Implementation ...
        }
    }
    class MyController : Controller
    {
        private readonly IMyDataLayer _datalayer;
        public MyController(IMyDataLayer datalayer)
        {
            _datalayer = _datalayer;
        }
        
        [HttpPost]
        public ActionResult SomeAction(SomeModel model)
        {
            if(ModelState.IsValid)
            {
                // Perform some manipulation on modeldata
                model.Value++;
                // Upload Model, Get ID
                model.Id = _datalayer.UploadToDb(model);
            }
            return View(model);
        }
    }
