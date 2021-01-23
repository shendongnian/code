    [RoutePrefix("Admin/SeeAlso")]
    public class SeeAlsoController : Controller
    {
       [HttpPost]
       [Route("Update")]
       public async Task<ActionResult> SeeAlso_Update(List<SubCategories> SelectedCategories)
       {
            if (SelectedCategories != null && ModelState.IsValid)
            { ... }
            return Json(ModelState.ToDataSourceResult());
       }
    } 
