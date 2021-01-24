    public class HomeController: Controller
    {
      public ActionResult MyAction(MyModel model)
      {
        return RedirectToAction("MySimilarAction", "About", new{model=model, age=40, name="my Name"});
      }
    }
    
    
    public class AboutController: Controller
    {
      public ActionResult MySimilarAction(MyModel model, int age, string name)
      {
        
      }
    }
