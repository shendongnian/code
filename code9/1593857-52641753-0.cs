    public class MyController
    {
        // ...
    
        [HttpPost]
        public ViewResult Search([FromForm]MySearchModel searchModel)
        {
            // ...
            return View("Index", viewmodel);
        }
    }
