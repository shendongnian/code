    using (var context = new Context()) // Create a new context for this
    {
        int theId = 33;
        var theNew = await context.News.FirstAsync(x => x.Id == theId);
        
        if (theNew != null)
        {
            var voted = await this.context.UserVoteNews.FirstAsync(x => x.UserId == this.UserId && x.NewId == theId);
        
            // Returns are mutually exclusive so clean up by removing else clauses
            if (voted != null)
            {
                return Ok("User voted");
            }
    
            return BadRequest(@"User didn't vote");
        }
        return NotFound();
    }
