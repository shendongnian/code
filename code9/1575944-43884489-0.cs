     [HttpGet]
        [MyAuthorize(Roles = "Project Manager")]
        public ActionResult Comment(int id)
        {
            var model= new Comment{
                ProjectId=id
            }
            return PartialView("Comment",model);
    
        }
    
        [HttpPost]
        [MyAuthorize(Roles = "Project Manager")]
        public ActionResult Comment(Comment comment)
        {    
                var com = new Comment
                {
                     ProjectManagerId = User.Identity.GetUserId(),
                     ProjectId= id,
                     CommentDesc =comment.CommentDesc
                };
                context.Comments.Add(com);
                context.SaveChanges();
                return RedirectToAction("Main", "Home");
        }
