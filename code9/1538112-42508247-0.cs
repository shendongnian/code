    IMongoCollection<Student> studentCollection = db.GetCollection<Student>("studentV1");
    
    Student updatedStudent = new Student() { AVG = 100, FirstName = "Shmulik" });
    
    
    MongoDB.Driver.Builders.QueryComplete myQuery = MongoDB.Driver.Builders.Query.And(MongoDB.Driver.Builders.Query.EQ("AVG", "100"),    MongoDB.Driver.Builders.Query.EQ("FirstName", "Shmulik"));
    
    var update = Update.Set("AVG", "500")
                        .Set("FirstName ", "New Name");
    
    studentCollection.Update(myQuery, update);
