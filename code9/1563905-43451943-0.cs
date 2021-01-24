    public void SAVE(List<int> list )
    
            {  
    var all = context.ReqForDoc.ToList();
                    var friends = context.ReqForDoc.Where(f => list.Contains(f.requestN)).ToList();
                    friends.ForEach(a =>
                    {
                        a.actual = 0;
                    });
              
                     context.SaveChanges(); // UPDATE RECORDS
                   
                   List<ReqInf> list2 = new List<ReqInf>(); 
                    list2 = context.ReqForDoc.Where(f => list.Contains(f.requestN)).ToList();
                    context.ReqForDoc.AddRange(list2); //INSERT NEW
                    list2.ForEach(a =>
                    {
                        a.actual = 1;
                        if (a.Status == 3) { a.Status = 92; }
                      
                        
        
                    });   //UPDATE INSERTED
                    context.SaveChanges(); }
