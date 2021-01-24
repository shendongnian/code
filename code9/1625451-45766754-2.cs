    var testQuery = testList.AsQueryable();
    // Alternative one
    var result1 = testQuery
        .ToInjectable() // Don't forget!!
        .Where(test => test.Levels.Any(l => l.LevelDetails.Any(ld => test.IsTestDateEarlierThan(ld.LevelDate, 1))))
        .ToList();
    // Alternative two: You get the point :)
    var result2 = testQuery
        .ToInjectable() // Don't forget!!
        .Where(test => test.HasAnyLevelDateAfterTestDays(1))
        .ToList();
