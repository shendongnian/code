    [HttpDelete]
    [ResponseType(typeof(Category))]
    public IHttpActionResult DeleteCategory(int id)
    {
        Category category = db.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        db.Categories.Remove(category);
        db.SaveChanges();
        return Ok(category);
    }
