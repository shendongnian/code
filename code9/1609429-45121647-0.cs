    public ActionResult DeletePost(int Id)
        {
            var Author = ApplicationDbContext.Users.ToList();
            var postToDelete = ApplicationDbContext.Posts.Single(c => c.Id == Id);
            var postAuthor = postToDelete.Author;
            postAuthor.Post_Id = null;
            postToDelete.Author = null;            
            ApplicationDbContext.Posts.Remove(postToDelete);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
