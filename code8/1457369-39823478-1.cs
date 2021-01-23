    public async Task<IHttpActionResult> PostAssessment(Assessment item)
    {
        using (var context = new DBContext())
        {
            Student theStudent = context.Students.Single(s => s.Id == item.Student.Id);
            item.StudentId = item.Student.Id;
            item.Student = null;   
            //context.Students.Attach(theStudent);
            context.Assemssments.Add(item);
            context.SaveChanges();
        }
        Assessment current = await InsertAsync(item);
        return CreatedAtRoute("Tables", new { id = current.Id }, current);  
    }
