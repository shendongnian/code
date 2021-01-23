    public static bool OpTest(IEnumerable<dynamic> model, IEnumerable<dynamic> existingEntities, Guid t)
    {
        List<dynamic> ids = existingEntities?.Select(x => x.Id).Except(model.Select(x => x.Id)).ToList();
        List<dynamic> check = existingEntities?.Where(o => ids.Any(c => c == o.Id && o.EffectiveTo >= DateTime.Today)).ToList();
        check?.AddRange(model);
        List<dynamic> dateModel = check.Select(x => new TimeInterval(x.EffectiveFrom, x.EffectiveTo)).ToList();
        return true;
    }
