    public int RecursiveCount(List<Comment> commentList)
    {
        int partialCount = commentList.Count();
                
        foreach (Comment c in commentList)
            if(c.Replies != null)
                partialCount += RecursiveCount(c.Replies);
        
        return partialCount;
     }
