    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(IdentityRole role)
    {
        try
        {
             _db.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return View();
        }
    }
