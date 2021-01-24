     return  await db.ApplicationUsers.Where(u=>u.Name.Contains(name) && !u.Deleted && u.AppearInSearch)
                                    .OrderByDescending(u => u.Verified)
                                    .Skip(page * recordsInPage)
                                    .Take(recordsInPage)
                                    .Select(u => new UserSearchResult()
                                    {
                                        Name = u.Name,
                                        Verified = u.Verified,
                                        PhotoURL = u.PhotoURL,
                                        UserID = u.Id,
                                        Subdomain = u.Subdomain
                                    })
                                    .ToList()
                                    .Select(<your new query>)
                                    .ToListAsync();
