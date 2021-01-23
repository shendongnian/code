    List<Asset> AllAssets = new[]
        {
            allAssets,
            _vheiclesList,
            _propertyList,
            _securedLoanAssets,
            _allSavings,
            _allPensions,
            _allOtherAssets,
        }
        .Where(x => x != null)
        .SelectMany(x => x)
        .ToList();
