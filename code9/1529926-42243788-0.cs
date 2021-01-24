    qurey1 = from a in CKS Group a by Key DOK into Group
             select DOK = Group.DOK, 
                    TOPLAM = Group.Select(x => x.GNL).Distinct().Count()
    
    query2 = from b in CKS 
             where SqlMethods.Like(b.ATUR, "%DIZ%")
             Group b by new Key {DOK, ATUR } into Group 
             select DOK  = Group.DOK, 
                    ATUR = Group.ATUR,
                    Adet = Group.Select(x => x.HST).Distinct().Count(),
                    adet = Group.Select(x => x.GNL).Distinct().Count()
    
    //the same way of query2, you can get query3. 
    
    //Then you can use a query23 to unit all of query2 and query3 
    query23 = (from x in db.Table1 select new {DIZ= x.A, OMUZ = 0})
              .Concat( from y in db.Table2 select new {DIZ = 0, DIZ = y.B} );
    
    //At last, you can put query1 and query23 together.
    query123 = from e in query1  
               join f in query23 
               on e.DOK equals f.DOK  
               into query
               from g in query.DefaultIfEmpty()
               select new { toplam = g.toplam , 
                            DIZ= g==null ? 0:g.DIZ ,
                            OMUZ = g==null?0:g.OMUZ   };
    
    //and then 
    var result = query123.ToList().
