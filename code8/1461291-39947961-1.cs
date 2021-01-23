    ActionResult PostComment(Post post, Comment comment)
    {
        PostAndComments postcomment = new PostAndComments
    		{
    			IDPost = post.ID,
    			IDComment = comment.ID,
    			etc... etc...
    		}
    }
