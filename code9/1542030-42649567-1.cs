    public IEnumerable<CommentViewModel> GetPostComments(long postId, int pageIndex, int pageSize)
    {
    
        return (from cm in _db.Comments
                where cm.PostId == postId
                select new CommentViewModel()
                {
                    CommentDetails = new Comment()
                    { Id = cm.Id, CDate = cm.CDate, UserId = cm.UserId, IsActive = cm.IsActive, IsDelete = cm.IsDelete, PostId = cm.PostId, Text = cm.Text },
                    CDate = cm.Date // Changed here
                })
                .OrderByDescending(cm => cm.CommentDetails.CDate)
                .Skip(pageIndex)
                .Take(pageSize)
                .ToList();
    }
