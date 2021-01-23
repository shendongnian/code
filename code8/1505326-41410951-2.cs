    var skills = db.Skills.ToDictionary(d => d.Id, n => n.Name);
    var jobData = (from j in db.Jobs
                    join c in db.Categories on j.CategoryId equals c.CategoryID 
                    select new
                    {
                        JobTitle = j.JobTitle,
                        JobID = j.JobID,
                        ReqSkillCommaSeperated = j.ReqSkills,
                        Category = c.Name
                        // Add other properties as needed
                    }).AsEnumerable()
        .Select(x => new
        {
            JobID = x.JobID,
            JobTitle = x.JobTitle,
            Category = x.Category,
            SkillNames = GetSkillName(x.ReqSkillCommaSeperated , skills)
        }).ToList();
