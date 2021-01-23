    public static bool OpTest<T>(List<T> model, List<T> existingEntities, Guid t) where T : class
        {
            //  var existingEntities = smRepository.GetStationMapping(t, StatusEnum.ALL); //smRepository.GetStationMapping(t, StatusEnum.ALL);
            var ids = existingEntities?.Select(x => x.Id).Except(model.Select(x => x.Id)).ToList();
            var check = existingEntities?.Where(o => ids.Any(c => c == o.Id && o.EffectiveTo >= DateTime.Today)).ToList();
            check?.AddRange(model);
            var dateModel = check.Select(x => new TimeInterval(x.EffectiveFrom, x.EffectiveTo)).ToList();
            return true;
        }
