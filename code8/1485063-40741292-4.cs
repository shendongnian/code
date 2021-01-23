    var answer = (from t1 in table1
                 join t2 in table2 on t1.Id equals t2.Id into subData1
                 from t2sub in subData1.DefaultIfEmpty()
                 join t3 in table3 on new { t2sub.Id, t2sub.condition } equals new { t3.Id, condition = 3 } into subData
                 from t3sub in subData.DefaultIfEmpty()
                 group new { t1, t2sub } by t1.Id into subGroup
                 orderby subGroup.Count(x => x.t2sub != null) descending 
                 select new {
                     Id = subGroup.Key,
                     OrderCol = subGroup.Count(x => x.t2sub != null)
                 }).ToList();
             
