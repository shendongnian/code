    public ActionResult Index()
    {
        var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
        var groupedOrders = orders.GroupBy(o => Customer.Name, o => o);
        // grouped orders is IEnumerable<string, IEnumerable<Order>>
        return View(groupedOrders);
    }
