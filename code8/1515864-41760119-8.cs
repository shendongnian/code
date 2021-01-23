    Person p = new Person
    {
    	Id = int.Parse(dt.Rows[0].Columns["PersonID"]),
    	Name = dt.Rows[0].Columns["Name"]),
    	Age = int.Parse(dt.Rows[0].Columns["Age"])
    };
    
    p.WorkExperiences = new List<Work>();
    
    List<Work> workExperiences = (from row in dt.AsEnumerable()
    							 select new Work
    							 {
    								 Id = row.Field<int>("WorkID"),
    								 WorkAddress = row.Field<string>("WorkAddress"),
    								 Position = row.Field<string>("Position")
    							 }).ToList();
    							 
    p.WorkExperiences.AddRange(workExperiences);
