    [ChildActionOnly]
    public ActionResult Orders()
    {
        List<Order> orders = .... // get orders for the current user
        return PartialView("_Orders", orders);
    }
