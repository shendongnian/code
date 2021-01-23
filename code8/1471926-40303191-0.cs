    else
    {
        var countries = Connection.ctx.Countries.OrderBy(x => x.CountryName).ToList();
        ViewBag.Countries = new SelectList(countries, "CountryId", "CountryName");
        return View("Register", model);
    }
