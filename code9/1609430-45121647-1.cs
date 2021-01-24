    public ActionResult DeletePost(int Id)
        {
            var allUsers = ApplicationDbContext.Users.ToList();
            var postToDelete = ApplicationDbContext.Posts.Single(c => c.Id == Id);
            foreach(var item in allUsers)
            {
                if (postToDelete.Subscribers.Contains(item))
                    postToDelete.Subscribers.Remove(item);
            }
            ApplicationDbContext.Posts.Remove(postToDelete);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
