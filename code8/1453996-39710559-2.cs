    [HttpPost]
    public ActionResult Edit(Order order)
    {
       if (ModelState.IsValid)
       {                                 
           context.Entry(order).State = EntityState.Modified;
           context.SaveChanges();
           // HERE order.OrderDetails is empty even if it was filled with a number of items
       }
    
       return View(order);
    }
