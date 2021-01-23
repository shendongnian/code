    using (var db = new Entities.WaveEntities()) 
      { 
        using (var dbContextTransaction = db.Database.BeginTransaction()) 
           { 
             try 
              { 
                var maxCaseReviewersSetID = db.CaseReviewerSets.Select(crs => crs.CaseReviewersSetId).Max();
                var emptyCHList = db.CaseHistories.Where(ch => ch.CaseReviewersSetID == null && ch.IsLatest == true && ch.StatusID != 100).ToList();
              
                foreach(var ch in emptyCHList) {
                   var newCaseReviewerSET = new Entities.CaseReviewerSet();
                   newCaseReviewerSET.CreationCHID = ch.CHID;
                   db.CaseReviewerSets.Add(newCaseReviewerSET);
                  }
        
                    db.SaveChanges(); 
                    dbContextTransaction.Commit(); 
              } 
         catch (Exception) 
            { 
               dbContextTransaction.Rollback(); 
            } 
     } 
    } 
