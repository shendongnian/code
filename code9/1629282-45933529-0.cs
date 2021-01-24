    int Id = 684;
    var result = myDbContext.CommentRottas
        .Where(comment => comment.Id == Id && comment.Status == 1)
        .OrderByDescending(comment => comment.Date)
        .Select(comment => new CommentDTO()
        {
            CommentId = comment.Id,
            Rotta = new RottaDTO
            {
                RottaId = comment.Rotta_Id,
                // not tested all properties
            },
            Client = new ClientDTO()
            {
                Id = comment.Client_Id,
                // not tested all properties  
            },
            CommentDate = comment.Date,
            Comment = comment.Comment,
        })
        .ToList();
