    IEnumerable<DummyCourse> GetDummyCoursesList()
    {
         yield return new DummyCourse()
         {
            CourseId = 1,
         };
         yield return new DummyCourse()
         {
            CourseId = 2,
         };
         yield return new DummyCourse()
         {
            CourseId = 3,
         };
    }
