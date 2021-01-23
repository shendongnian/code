    var answer = (from t1 in table1
                 join t2 in table2 on new { t1.Id, condition = 3} equals new { t2.Id, t2.condition } into subData
                 from t2sub in subData.DefaultIfEmpty()
                 group new { t1, t2sub } by t1.Id into subGroup
                 orderby subGroup.Count(x => x.t2sub != null) descending 
                 select new {
                     Id = subGroup.Key,
                     OrderCol = subGroup.Count(x => x.t2sub != null)
                 }).ToList();
             
