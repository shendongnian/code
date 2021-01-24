    public JsonResult IsCourseNameExist(string CourseName)
    {
        if(dbContext.Courses.Any(x => x.CourseName.Trim().ToUpper().Equals(CourseName.Trim().ToUpper())
        {
            // return error
        }
        else
        {
            // continue on
        }
    }
