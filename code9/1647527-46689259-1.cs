    public ActionResult Seed()
    {
        using(var context = new CUDbContext())
        {
            Seeder.Seed(context);
        }
        return Content("Ok")
    }
