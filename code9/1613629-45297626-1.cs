    [HttpPost]
    public ActionResult Create(DonHang dh)
    {
        if (ModelState.IsValid)
        {
            try
            {
                ...
                //dh.kid = 29;    //Comment out or remove this line
                ...
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return View();
    }
