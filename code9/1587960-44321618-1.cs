    using (var db = new ModelDB())
    {
    
        var entity = db.Issue_Detail.FirstOrDefault(i => i.issue_id == (int)issue.issue_id);
        if (entity == null)
        {
            //handle error:
            throw new Exception("Issue not found");
        }
        //here we update the properties:
        db.Entry(entity).CurrentValues.SetValues(issue);
        db.SaveChanges();
    
        status = true;
    }
