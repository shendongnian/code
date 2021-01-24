    public class OrderController : Controller
    {
        private readonly IOrderService service;
        public ProductController(IOrderService service)
        {
            this.service = service;
        }
 
        [Post]       
        public ActionResult CancelOrder(Guid orderId)
        {
            this.service.CancelOrder(orderId);
            return this.Ok();
        }
    }
