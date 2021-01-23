     var v = from q in myTable
                    where q.Child_ID != null
                    orderby q.ModifiedDate descending
                    select q;
            
            var result2 = v
                .GroupBy(g => new
            {
                g.Main_ID
            })
             .Select(grp => new MyClass
             {
                 Main_ID = grp.Key.Main_ID,
                 StartCount = grp.Where(x=> x.Activity == "Start").Select(x => x.Child_ID).Distinct().Count(),
                 StopCount = grp.Where(x => x.Activity == "Stop").Select(x => x.Child_ID).Distinct().Count()
             });
