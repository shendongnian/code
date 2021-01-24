    public ActionResult Index()
    {
        //Initialize the view with an empty default entry
        var vm = new List<Foo> {
            new Models.Foo {
                Cat ="foo",
                Name =" bar"
            }
        };
        return View(vm);
    }
    
    //this calls your partial view and initializes an empty model 
    public PartialViewResult AddFile()
    {
        return PartialView("_AddFile", new Foo());
    }
    
    //note "files" name? The same as our collection name specified earlier
    [HttpPost]
    public ActionResult PostFiles(IEnumerable<Foo> files)
    {
        //do whatever you want with your posted model here
        return View();
    }
