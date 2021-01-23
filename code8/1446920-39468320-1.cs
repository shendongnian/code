    return results.Select(x=>new WrapperDynamic(x))
    .Select(result => new Solution
            {
                IsDeleted = result.IsDeleted,
                FriendlyName = result.FriendlyName,
                DecisionLevel = (DecisionLevel?)result.DecisionLevel,
            }).ToList();
