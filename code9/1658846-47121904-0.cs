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
