    public ActionResult Basket()
    {
        //Getting the cookie which has the name "userId" and assigning that to a variable.
        string userId =  Request.Cookies.Get("userId").Value;
        var basket = _context.Basket.Where(x => x.UserId == userId);       
        return View(basket);
    }
