    _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            int userId = _context.Users
                .Where(u => u.UserName == Options.UserName)
                .FirstOrDefaultAsync()
                .Id;
    ...
