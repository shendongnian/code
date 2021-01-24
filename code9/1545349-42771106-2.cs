    public ActionResult Index()
    {
        var CustomerVMlist = (from Cust in db.Customers
                              join Ord in db.Orders 
                              on Cust.CustomerID equals Ord.CustomerID
                              select new CustomerVM
                              { 
                                  Name = Cust.Name, 
                                  Mobileno = Cust.Mobileno, 
                                  Address = Cust.Address, 
                                  OrderDate = Ord.OrderDate, 
                                  OrderPrice = Ord.OrderPrice
                              }).ToList();
        return View(CustomerVMlist)
    }
    
