    public async Task<IHttpActionResult> PostAssessment(Assessment item)
    {
        using (var context = new DBContext())
        {
            Student theStudent = context.Students.Single(s => s.Id == item.Student.Id);
            item.Student = null;//Just to make sure there is not other relationship here
            //because 'theStudent' was retreived from the db it will be in the change graph so any changes will be recoreded
            theStudent.Assessments.add(item);//I am assuming it should be added because it is a POST method   
            context.SaveChanges();
        }
        Assessment current = await InsertAsync(item);
        return CreatedAtRoute("Tables", new { id = current.Id }, current);  
    }
