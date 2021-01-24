    public class MainController : Controller
    {
      public ActionResult ShowMeTheModel()
      {
        SimpleModel model = new SimpleModel
        {
          FromDate = DateTime.Today,
          ToDate = DateTime.Today.AddDays(7)
        };
        return View(model);
      }
      [HttpPost]
      public ActionResult UpdateTheModel(SimpleModel model)
      {
        // use the model parameter to persist changes or otherwise        
        return Redirect("ShowMeAllTheModels");
      }
    }
