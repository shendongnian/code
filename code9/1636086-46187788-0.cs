       var listD =
           from a in listA
           join b in listB on a.bId equals b.Id
           join c in listC on b.cId equals c.Id
           select new {
                aId = a.Id,
                aName = a.Name,
                aSample = a.Sample,
                bId = b.Id, 
                bName = b.Name, 
                bComment = b.Comment, 
    
                cId = c.Id,
                cName = c.Name,
                cInterval = c.Interval
           };
       
