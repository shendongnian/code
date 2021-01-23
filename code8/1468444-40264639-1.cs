      public virtual RequestsModel GetAdvertises(int AdID)
            {
                return _requests
                    .AsNoTracking()
                    .Include(v => v.ViewCounts)
                    .Cacheable()
                    .FirstOrDefault(a => a.Id == AdID && a.Type == 1);
            }
