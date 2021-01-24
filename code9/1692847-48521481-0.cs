    public class ItemsController : Controller
    {
        public ActionResult Add()
        {
            // add item and save changes
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ItemHub>();
            hubContext.Clients.Invoke("ItemsUpdated", itemsList);
        }
    }
