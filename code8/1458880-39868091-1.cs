    public ActionResult GetStudents(int labId, string userName, bool isAll)
    {
        var allRecords = repository.Students;
        //If isAll, get all the records having StatusId = 1
        if (isAll) 
        { 
            var result = allRecords.Where(m => m.StatusId == 1 
                                                && m.LabId == labId 
                                                && m.UserName == username);
            //or
            var result = from record in allRecords
                             where record != null &&
                                   record.StatusId == 1
                                   && !string.IsNullOrWhiteSpace(record.UserName)
                                   && record.UserName.Equals(username)
                                   && record.Labid = labId
                             select record;
        } 
        else 
        { 
           // do else things
        }
    }
