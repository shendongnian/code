    public class ItemsController
    {
        IQueryHandler<PagedQuery<GetAllItemsQuery, Item>, Paged<Item>> handler;
        public ItemsController(
            IQueryHandler<PagedQuery<GetAllItemsQuery, Item>, Paged<Item>> handler)
        {
            this.handler = handler;
        }
        public ActionResult Index(PagedQuery<GetAllItemsQuery, Item> query)
        {
            return View(this.handler.Handle(query));
        }
    }
