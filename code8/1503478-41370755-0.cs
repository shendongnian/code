        using NHibernate;
        using NHibernate.Criterion;
        using NHibernate.Linq;
        using NHibernate.Transform;
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
..........
                var q2 = db.Query<cat>()
                    .Where(x => x.catId== 0 && x.dr == true);
    
                q2 = from t1 in q2
                     join t2 in db.Query<cat>() on t1.id equals t2.catId
                     where t2.st< DateTime.Now && t2.dr== true
                     select t2;
    
                //for result list
                var myList = q2.ToList();
