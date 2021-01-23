    public Task<ActionResult> AngularData(Animal animal)
    {
        db.Animals.Add(animal);
        db.SaveChanges();
        return Json(new { foo = "bar", baz = "Blech" });
    }
