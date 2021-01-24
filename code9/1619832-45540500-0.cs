    DateTime maxTastdate=db.Test.Max(c=>c.TestDate);
    var result=( from e in db.Engine 
                 join t in db.Test.where(c=>c.TestDate=maxTastdate) on e.EngineID  equlas t.EngineID into jj from kk in jj.DefaultIfEmpty()
                 select new {
                               EngineId=e.EngineId,
                               Make=e.Make,
                               Model=e.Model,
                               SerialNumber=e.SerialNumber
                               Value1=kk.Value1,
                               Value2=kk.Value2
                            }).Tolist()
