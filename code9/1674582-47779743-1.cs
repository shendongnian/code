    public IHttpActionResult DeleteStudent(string id)
     {
       if (id == null)
         return BadRequest("Not a valid student id");
           var student = sd.Students
                    .Where(s => s.StudentID == id)
                    .SingleOrDeault();
        if(student!=null)
        {
          //perform operation
        }    
        return Ok();
    }
