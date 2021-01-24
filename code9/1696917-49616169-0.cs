        public async Task<List<Comment>> GetAsync(int blogId)
        {
            var comments = await _context.Comments
                .Include(x => x.User)
                .OrderByDescending(x => x.PublishedDate)
                .Where(x => x.ParentBlog.Id == blogId && !x.IsDeleted).ToListAsync();
            
            comments = await GetRepliesAsync(comments);
            return comments;
        }
        private async Task<List<Comment>> GetRepliesAsync(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                var replies = await GetFromParentIdAsync(comment.Id);
                if (replies != null)
                {
                    comment.Replies = await GetRepliesAsync(replies.ToList());
                }
            }
            return comments;
        }
