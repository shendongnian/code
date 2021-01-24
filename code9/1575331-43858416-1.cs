    //use your database dbcontext
           using (BreazEntities21 db = new BreazEntities21())
            {
                int[] a1 = { 5, 6 };
                var r1 = (from row in db.theProducts
                         where a1.Contains((int)row.id)
                         select row).ToList();
                int[] a2 = { 7 };
                var r2 = (from row in db.theProducts
                         where a2.Contains((int)row.id)
                         select row).ToList();
                var mergedList = r1.Union(r2).ToList();
                var summation = mergedList.Sum(r => r.id);
                var s1 = new JavaScriptSerializer().Serialize(summation);
            }
