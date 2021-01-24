    protected void DeleteComment(comment c)
    {
        int id = c.id
    
        //Three lists to hold the self-referencing objects
        List<comment> rootCommentsToBeDeleted = new List<comment>();
        List<comment> parentCommentsToBeDeleted = new List<comment>();
        List<comment> commentsToBeDeleted = new List<comment>();
    
        using (phEntities db = new phEntities())
        {
                    
            //Get all comments to lists
            rootCommentsToBeDeleted = db.comments.Where(x => x.root_id == id).ToList<comment>();    
            parentCommentsToBeDeleted = db.comments.Where(x => x.parent_comment_id == id).ToList<comment>();    
            commentsToBeDeleted = db.comments.Where(x => x.id == id).ToList<comment>();    
    
            //Combine lists
            commentsToBeDeleted.AddRange(rootCommentsToBeDeleted);
            commentsToBeDeleted.AddRange(parentCommentsToBeDeleted);
    
            //Delete records
            db.comments.RemoveRange(commentsToBeDeleted);
            db.SaveChanges();
    
        }
    
    }
