     public async Task<IEnumerable<SchedulerJob>> GetAllByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Context.SchedulerJobs
                .Include(s => s.Program)
                .Where(job => ids.Contains(job.Id))
                .ToListAsync(cancellationToken);
        }
