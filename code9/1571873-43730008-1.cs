    [HttpPost]
    public ActionResult StudentList(StudentListModel studentListModel)
    {           
    int SelectedStudentValue = studentListModel.SelectedStudentId;
     // Do other operations with the id
     return View();
    }
