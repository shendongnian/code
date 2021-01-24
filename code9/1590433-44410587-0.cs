    public List<Base> GetAllLists() {
        var studentList = new StudentService().GetList();  
        var teacherList = new TeacherService().GetList();  
        return studentList.Cast<Base>()
            .Concat(teacherList.Cast<Base>())
            .ToList();
    }
