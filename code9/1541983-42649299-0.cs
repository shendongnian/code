      protected void DeleteChildComments(comment c, phEntities db) {
       if (c != null) {
        // get all comments with c.id as its parent_id
        List <comment> oneLevelDownSubComments = new List <comment> ();
    
        oneLevelDownSubComments =
            db.comments.Where(x => x.parent_comment_id == c.id).ToList <comment> ();
    
        if (oneLevelDownSubComments.Count == 0) {
         // no children, just delete the comment
    
         db.comments.Remove(c);
         db.SaveChanges();
        } else {
         // has children, delete them
         foreach(var item in oneLevelDownSubComments) {
          DeleteChildComments(item, db);
         }
    
         // delete itself if has no children
         DeleteChildComments(c, db);
        }
       }
      }
