     public ICollection<Object> GetRouteComments(long Id)
        {
            /*
            var result = await _ctx.CommentRottas
                            .Where(s => s.Rotta_Id == Id)
                            .Include(s => s.Client)
                            .Where(s => s.Status == 1)
                            .OrderByDescending(p => p.Date)
                            .ToListAsync();
            */
            var comments = (from p in _ctx.CommentRottas
                               .Where(s => s.Rotta_Id == Id && s.Status == 1)
                               .Include(s => s.Client)
                            orderby p.Date descending
                            select new CommentDTO
                            {
                                CommentId = p.Id,
                                Rotta = new RottaDTO
                                {
                                    RottaId = p.Rotta_Id,
                                    RottaDate = p.SU_ROUTES.Date,
                                    ClientId = p.SU_ROUTES.ClientId,
                                    COMMENTS_NUM = p.SU_ROUTES.COMMENTS_NUM,
                                    LIKES_NUM = p.SU_ROUTES.LIKES_NUM,
                                },
                                Client = new ClientDTO
                                {
                                    Id = p.Client_Id,
                                    UserName = p.Client.UserName,
                                    Profile_Image = p.Client.Profile_Image,
                                },
                                CommentDate = p.Date,
                                Comment = p.comment,
                            }
                            )
                            .ToList().Cast<Object>().ToList();
    
            return comments;
        
