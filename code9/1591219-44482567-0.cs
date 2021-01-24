    [TestMethod,Isolated]
    public void TestMethod1()
    {
        var fakeDBContextDal = Isolate.Fake.NextInstance<DbContextDal>();
        var s = new Student();
        var c = new Course();
        s.ID = 1;
        c.ID = 2;
    
        var e = new Enrollment();
        e.Grade = 100;
    
        Isolate.WhenCalled(() => fakeDBContextDal.Enrollments.Find(1,2)).WithExactArguments().WillReturn(e);
    
        Assert.AreEqual(s.getGradeInCourse(c), 100);
    }
