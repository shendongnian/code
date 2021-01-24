    private List<LoadedDataSource> GetAssociatedValues(IReadOnlyCollection<List<LoadedDataSource>> indexRows, List<LoadedDataSource> values)
    {
        var ret = values;
        if ((ValueColumn.LinkKeys & ReportLinkKeys.ContainerId) > 0 &&
            ret.Any(t => t.ContainerId.HasValue))
        {
            var indexes = indexRows
                .Where(i => i.CheckContainer)
                .Select(i => new HashSet<int>(i
                    .Where(h => h.ContainerId.HasValue)
                    .Select(h => h.ContainerId.Value)))
                .ToList();
            ret = ret.Where(v => v.ContainerId == null 
                            || indexes.All(i => i.Contains(v.ContainerId)))
                     .ToList();
        }
        if ((ValueColumn.LinkKeys & ReportLinkKeys.EnterpriseId) > 0 &&
            ret.Any(t => t.EnterpriseId.HasValue))
        {
            var indexes = indexRows
                .Where(i => i.CheckEnterpriseId)
                .Select(i => new HashSet<int>(i
                    .Where(h => h.EnterpriseId.HasValue)
                    .Select(h => h.EnterpriseId.Value)))
                .ToList();
            ret = ret.Where(v => v.EnterpriseId == null 
                            || indexes.All(i => i.Contains(v.EnterpriseId)))
                     .ToList();
        }
        return ret;
    }
