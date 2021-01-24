    public IEnumerable<JobsViewModel> GetJobsViewModels(
        Guid vesselId,
        int status,
        Func<JobsViewModel, bool> predicate = null)
    {
        // We're never filtering by JobsNoSubsYpdcResult, but this
        // satisfies overload resolution
        Func<JobsNoSubsYpdcResult, bool> resultPredicate = null;
        return predicate == null
            ? GetJobsViewModels(vesselId, status, resultPredicate)
            : GetJobsViewModels(vesselId, status, resultPredicate).Where(predicate);
    }
