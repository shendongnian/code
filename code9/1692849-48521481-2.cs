    public class ItemsController : Controller
    {
        public ActionResult Add()
        {
            // add item and save changes
            // ...
            // then invoke the hub
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ItemHub>();
            hubContext.Clients.Invoke("ItemsUpdated", itemsList);
        }
    }
