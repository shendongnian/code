    using (MyContext ctx = new MyContext())
           {
               var orderEntity = ctx.Order.FirstOrDefault(x=> x.OrderID == ord.OrderID);
                orderEntity.StatusID = 3;
                 ctx.SaveChanges();
    
             return CreatedAtRoute("DefaultApi", new { id = ord.OrderID }, ord);
           }
