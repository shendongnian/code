    var selectedSubject = db.Subjects.FirstOrDefault(a=> a.id == record.SubjectId);
    if(selectedSubject!=null)
    {     
      if (record.Marks < selectedSubject.MinMarks)
      {
        record.Result = "Fail";
      }
      else if (record.Marks > selectedSubject.MaxMarks)
      {
        record.Result = "Error";
      }
      else
      {
        record.Result = "Pass";
      }
    }
    else
    {
      ModelState.AddModeError(string.empty,"Subject not found");
    }
    //to do : Reload dropdown data and return the view
