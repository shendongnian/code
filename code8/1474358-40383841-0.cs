    public ActionResult DeleteConfirmed(int id)
    {
        DeletePost(id);            
        return RedirectToAction("Index");
    }
    private void DeletePost(int id)
    {
        Post post = db.Posts.Find(id);
        db.Posts.Remove(post);
        db.SaveChanges();            
    }
