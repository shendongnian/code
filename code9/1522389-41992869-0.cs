     using System.Data.Entity.Migrations;  
 
     public HttpResponseMessage Update([FromBody]List<Model> json)
        {
            var result = db.Models.ToList();
           
            // create object from dbContext
            var db = new MyDbContext();
            
            // add entities on dbContext,
            db.SomeRepo.AddOrUpdate(json); 
            // commit the change on db
            db.Save();  
            
            return response;
        }
