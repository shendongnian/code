    var allLists = new List<Base>();
    var studentList = new StudentService().GetList();  
   
    allLists.AddRange(studentList);
    var teacherList = new TeacherService().GetList();  
    allLists.AddRange(teacherList);
