    public IActionResult Offers()
    {
        GetInfo = new GetInfo();
        GetInfo.GetOffers();
        return View(GetInfo);
    }
