    private async Task<Comment> GetComment(Guid id, CancellationToken cancellationToken)
    {
    	var wm = await _context.Comments
    						   .Include(x => x.Replies)
    						   .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    
    	for (var i = 0; i < wm.Replies.Count; i++)
    	{
    		if (!wm.Replies[i].IsDeleted)
    			wm.Replies[i] = await GetComment(wm.Replies[i].Id, cancellationToken);
    	}
    
    	return wm;
    }
