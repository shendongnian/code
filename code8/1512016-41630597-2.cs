    DataTable dtResult=dtOriginal.Clone();
    dtOriginal.AsEnumerable()
               .GroupBy(x => x.Field<string>("Player"))
               .Select(y=> new {  
                                Index=String.Join(",", y.Select(z => z.Field<string>("Index"))),
                                Player=y.Key, 
                                Score=y.Sum(sc=>sc.Field<int>("Score"))
                                })
               .ToList()
               .ForEach(i => {dtResult.Rows.Add(i.Index, i.Player, i.Score);});
