    public class StudentListModel
    {
     public List<Student> StudentList{ get; set;}
     public SelectList StudentSelectList { get; set;}
     public int SelectedStudentId { get; set;}
    }
    [HttpGet]
    public ActionResult StudentList()
    {
        StudentListModel studentList = new StudentListModel();
        studentList.StudentList = //Code to load the student.
        studentList.StudentSelectList = new SelectList(studentList.StudentList, "StudentId", "StudentName");
        return View(studentList);
    }
