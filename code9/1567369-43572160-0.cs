    [HttpGet]
    public ActionResult Products()
    {
        var prList = this.GetProducts();
        return View(prList);
    }
    [HttpPost]
    public ActionResult Products(FormCollection fc) 
    {
        var prList = this.GetProducts();
        // TODO: based on the search parameter sent from the client
        // here you probably want to filter the prList before passing it
        // back to the view
        return View(prList);
    }
    private List<Product> GetProducts()
    {
        List<Product> prList = new List<Product>();
        Product p1 = new Product();
        p1.ProductName = "J & J";
        p1.Price = 40;
        p1.Ratings = 5;
        prList.Add(p1);
        Product p2 =  new Product();
        p2.ProductName = "Himalaya";
        p2.Price = 20;
        p2.Ratings = 2;
        prList.Add(p2);
        return prList;
    }
