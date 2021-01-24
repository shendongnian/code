    result = await _context.tblTime.FromSql("...").ToListAsync();
    List<TimeViewModel> viewModel = result .Select(a => new TimeViewModel()
                                                  {
                                                       Minutes = a.Minutes,
                                                       Seconds = a.Seconds
                                                   }).ToList();
