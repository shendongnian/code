    [HttpPost]  
    public string LessonsSelect([FromBody]RootObject data)
        {
         foreach(var lessid in data.LessonId )
           {
           var stdntLess = new StudentLesson ();
           stdntLess.StudentID = data.StudentId;
           stdntLess.LessonId = lessid;
           db.StudentLesson .Add(stdntLess);
           db.SaveChanges();
        }
          return "lesson selected";
        }
