    public IEnumerable<JobsViewModel> GetJobsViewModels(Guid vesselId, int status, Func<JobsNoSubsYpdcResult, bool> predicate = null) =>
        Mapper.Map<IEnumerable<JobsViewModel>>(_procedureService.Tech_GetJobsNoSubsYPDC(vesselId, status))
            .OptionalWhere(predicate);
    public IEnumerable<JobsViewModel> GetJobsViewModels(
        Guid vesselId,
        int status,
        Func<JobsViewModel, bool> predicate = null)
    {
        // We're never filtering by JobsNoSubsYpdcResult, but this
        // satisfies overload resolution
        Func<JobsNoSubsYpdcResult, bool> resultPredicate = null;
        return GetJobsViewModels(vesselId, status, resultPredicate)
            .OptionalWhere(predicate);
    }
