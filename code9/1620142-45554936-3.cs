    public class ItemsController : Controller
    {
        public IActionResult Get(int? id) 
        { 
            if (id.HasValue()) { // logic as in second action }
            else { // first action logic }
        }
    }
