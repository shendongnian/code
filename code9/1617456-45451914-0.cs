     public void SaveFileToDatabase(string type)
        {                          
               General_File toModify = _ctx.General_Files.Include("Small_Files")
    .Where(s => s.Type== type).OrderByDescending(s => s.id).FirstOrDefault();
                   this.local_generalFile.Small_Files = toModify.Small_Files;
                   
                   // do stuff with this.local_generalFile.Small_Files
    
                  _ctx.SaveChanges();
        }
