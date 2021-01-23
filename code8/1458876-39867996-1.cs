    public ActionResult GetStudents(int labId, string userName, bool isAll)
    {
        var allRecords = repository.Students;
        //If isAll, get all the records having StatusId = 1
        if (isAll) 
        { 
           var result = allRecords.Where(m => m.StatusId == 1  && m.UserName == userName  && m.LabId == labId); 
        } 
        else 
        { 
           // do else things
        }
    }
