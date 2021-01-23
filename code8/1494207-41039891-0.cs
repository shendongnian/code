    public ActionResult Index(DateTime? start, DateTime? end)
        {
      ViewBag.start = start;
                ViewBag.end = end;
            var orders = db.Orders
                .Where(x => x.OrderStatus == 3
                && x.ClosedAt > start
                && x.ClosedAt < end)
                .OrderByDescending(x => x.LastUpdateAt)
                .ToList();
    
        
            return View(orders);
        }
