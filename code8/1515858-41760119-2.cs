    Person p = new Person
    {
    	Id = int.Parse(dt.Rows[0].Columns["PersonID"]),
    	Name = dt.Rows[0].Columns["Name"]),
    	Age = int.Parse(dt.Rows[0].Columns["Age"])
    };
    
    p.WorkExperiences = new List<Work>();
    
    List<Work> workExperiences = (from myRow in dt.AsEnumerable()
    							 select new Work
    							 {
    								 Id = int.Parse(dt.Rows[0].Columns["WorkID"]),
    								 WorkAddress = dt.Rows[0].Columns["WorkAddress"]),
    								 Position = dt.Rows[0].Columns["Position"])
    							 }).ToList();
    							 
    p.WorkExperiences.AddRange(workExperiences);
