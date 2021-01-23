    Repository<College> _reColl = new Repository<College>();
    var college = new College
    {
        Name = "TestCollege"
    };
    _reColl.Add(college)
    _reColl.save();
    
    // As long as you have the same reference your college will get an Id after you inserted it.
    
    Repository<Student> _reStu = new Repository<Student>();
    _reStu.Add(new Student { Name = "Test", CollegeId = college.Id, Lessons = null });
    _reStu.save();
