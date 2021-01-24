    private HttpClient client = new HttpClient();
    
    public HomeController()
    {
        client.BaseAddress = new Uri("http://localhost:49277");
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    [HttpPost]
    public ActionResult Insert(Order order)
    {
         HttpResponseMessage response = client.PostAsJsonAsync<Order>("/Order/Post" + $"/{order.OrderID}", order).Result;
         return RedirectToAction("Index");
    }
