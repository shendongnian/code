        public async Task<Sample> FindByIdAsync(Guid id, bool includeDeleted = false, bool forceRefresh = false)
        {
            var result = await GetAll()
                .Include(s => s.SampleItems)
                .IgnoreQueryFilters(includeDeleted)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (forceRefresh)
            {
                await _sampleRepository.DetachAsync(result);
                return await FindByIdAsync(id, includeDeleted);
            }
            return result;
        }
