        var citizens = await _stateProvider.SelectWhere(whereParams);
        var retDto = new PercentGroupBy()
        {
            Total = citizens.Count,
            Elements = citizens
            .Where(p => p.Content.Current != null)
            .GroupBy(p => p.Content.Current.AggState.ToString())
            .ToDictionary(g => g.Key, g => g.Count())
        };
        return retDto;
