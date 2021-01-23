    List<Data> data = //....;
    Dictionary<string, Teacher> teachers = new Dictionary<string, Teacher>();
    Dictionary<string, School> schools = new Dictionary<string, School>();
    foreach (var item in data)
    {
       if (item.TeacherId not in teachers)
          teachers.add(item.TeacherId, new Teacher(item.TeacherId, item.TeacherName));
    }
    foreach (var item in data)
    {
       if (item.SchoolId not in schools)
          schools.add(item.SchoolId , item.SchoolName, new School(item.SchoolId , teachers[item.SchoolId]));
    }
    List<School> gen_schools =     // get values from schools;
