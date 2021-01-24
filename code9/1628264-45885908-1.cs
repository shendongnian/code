    public List<UserViewModel> GetUserViewModelBy(int scoreFilter, string filter1= "", string filter2)
            {
                IQueryable<Result> query = _context.Results.Where(i => i.score==scoreFilter)).Include(x => x.Target)
                                                                   .Include(x => x.Target.Results.ToList())
                                                                   .Include(x => x.User)
    .Include(x=>x.User.Targets.Where(i=>i.Language.ToLower().Contains(filter1)).ToList());
    
                if (!string.IsNullOrEmpty(filter2))
                {
                    query = query.Where(x => x.Target.Language.ToLower().Contains(filter2));
                }
    
                return query.Select(x => new UserViewModel()
                {
                    otherProperty = x.User.otherProperty,
                    targets = x.User.targets,
                    results = x.Results
    
                }).ToList();
            }
