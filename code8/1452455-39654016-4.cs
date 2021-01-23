        string cacheKey = "GradeList";
        Mock<ICache> mockObject = new Mock<ICache>();
        List<Grade> grades = new List<Grade>
        {
            new Grade() {Id = 1, Name = "A*"},
            new Grade() {Id = 2, Name = "A"},
            new Grade() {Id = 3, Name = "B"},
            new Grade() {Id = 4, Name = "C"},
            new Grade() {Id = 5, Name = "D"},
            new Grade() {Id = 6, Name = "E"}
        };
        var mockedObjectCache = new Mock<ICache>();
        // Setup mock's Set method
        mockedObjectCache.Setup(m => m.Get(cacheKey)).Return(grades);
        
        // Test that the dependent class acts correctly according to the grades that exist in the cache
        var myDependentClass = new myDependentClass(mockedObjectCache.Object);
        var gradesCount = myDependentClass.CountGradesInCache();
        
        Assert.AreEqual(6, gradesCount);
