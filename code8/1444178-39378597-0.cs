    public static bool OpTest(IEnumerable<IMyInterface> model, IEnumerable<IMyInterface> existingEntities, Guid t)
    {
        List<SomeType> ids = existingEntities?.Select(x => x.Id).Except(model.Select(x => x.Id)).ToList();
        List<IMyInterface> check = existingEntities?.Where(o => ids.Any(c => c == o.Id && o.EffectiveTo >= DateTime.Today)).ToList();
        check?.AddRange(model);
        List<TimeInterval> dateModel = check.Select(x => new TimeInterval(x.EffectiveFrom, x.EffectiveTo)).ToList();
        return true;
    }
