    public static class TestExpressions
    {
        [InjectLambda]
        public static bool IsTestDateEarlierThan(this Test test, DateTime? dateTime, int numberOfDays)
        {
            return dateTime > test.TestDate.AddDays(numberOfDays);
        }
    
        public static Expression<Func<Test, DateTime?, int, bool>> IsTestDateEarlierThan()
        {
            return (test, dateTime, numberOfDays) => dateTime > DbFunctions.AddDays(test.TestDate, numberOfDays);
        }
        // Simple caching...
        private static readonly Func<Test, int, bool> _hasAnyLevelDateAfterTestDays = HasAnyLevelDateAfterTestDays().Compile();
        
        [InjectLambda]
        public static bool HasAnyLevelDateAfterTestDays(this Test test, int numberOfDays)
        {
            return _hasAnyLevelDateAfterTestDays(test, numberOfDays);
        }
        
        public static Expression<Func<Test, int, bool>> HasAnyLevelDateAfterTestDays()
        {
            return (test, numberOfDays) => test.Levels.Any(l => l.LevelDetails.Any(ld => test.IsTestDateEarlierThan(ld.LevelDate, numberOfDays)));
        }       
    }
