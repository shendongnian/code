            public async Task<IEnumerable<Models.Entities.Federation>> FederationWithEntities()
            {
                using (Models.DataAccessLayer.CompetitionContext _db = new CompetitionContext())
                {
                    return _db.Federations.Include(x => x.Clubs)
                                          .Where(x => !x.DeletedAt.HasValue && x.Clubs.Any(y => !y.DeletedAt.HasValue)).ToListAsync();
                }
            }
