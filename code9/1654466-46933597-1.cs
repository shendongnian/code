    [Route("Edit/{studentId:int}")]
        public ActionResult Edit([FromUri] int studentId)
        {
            //Get the student from studentList sample collection 
            var std = studentList.Where(s => s.StudentId == StudentId).FirstOrDefault();
    
            return View(std);
        }
