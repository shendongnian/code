     [Authorize]
    public ActionResult ImagenesPublicacion(int id)
    {
       ViewBag.Id = id.ToString();
       return View();
    }
