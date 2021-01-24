    public IEnumerable<CompletedJobViewModel> GetCompletedJobsViewModels<TKey>(Guid vesselId, int year, Func<TechArchiveNoSubsYpdcResult, bool> predicate = null, Func<TechArchiveNoSubsYpdcResult,TKey> keySelector = null) {
        var res = Mapper.Map<IEnumerable<CompletedJobViewModel>>(GetArchiveNoSubsYpdcResults(vesselId, year).OptionalWhere(predicate));
        if (keySelector != null) {
            res = res.OrderBy(keySelector);
        }
        return res;
    }
