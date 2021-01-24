    using AutoMapper.QueryableExtensions;
    var parts = _context.Parts
                    .Include(part => part.Whatever)
                    .OrderByDescending(part => part.Whatever)
                    .AsNoTracking()
                    .ProjectTo<PartsListViewModel>()
