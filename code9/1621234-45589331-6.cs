    public class OrderController : Controller
    {
        public ActionResult OrderInfo(int orderId)
        {
            OrderInfoViewModel viewModel = GetViewModel(orderId);
            return View(viewModel);
        }
    
        public PartialViewResult OrderLineItems(int orderId)
        {
            IEnumerable<OrderItem> orderItems = GetOrderItems(orderId);
            return Partial(orderItems);
        }
    }
