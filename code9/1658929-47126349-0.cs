     [Authorize]  //add this to the method   
     public ActionResult Create(Post post, HttpPostedFileBase upload)
            {
        
                string currentUserId = User.Identity.GetUserId();
                Post postObje = new Post();
                [postObje = post;
                ApplicationUser postMaker = db.Users.Find(currentUserId);
                if (ModelState.IsValid)
                {
                    postObje.PostMaker.Id = currentUserId; //(Error is in this line)
                    db.Post.Add(postObje);
                    db.SaveChanges();
                }
        }
