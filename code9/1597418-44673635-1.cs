    public IEnumerable<JobsViewModel> GetJobsViewModels(
        Guid vesselId,
        int status,
        Func<JobsViewModel, bool> predicate = null)
    {
        // We're never filtering by JobsNoSubsYpdcResult, but this
        // satisfies overload resolution
        Func<JobsNoSubsYpdcResult, bool> resultPredicate = null;
        var allResults = GetJobsViewModels(vesselId, status, resultPredicate);
        return predicate == null
            ? allResults : allResults.Where(predicate);
    }
