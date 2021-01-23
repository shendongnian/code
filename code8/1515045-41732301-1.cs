    public List<LinqResult> GetRec(int hid)
     {
         List<int> intList = new List<int>() { 1, 2, 5, 8, 9, 6, 3, 2, 4, 5, 6, 3, 2, 4, 855, 6, 2, 4, 6, 1, 56, 3 };
         var list = (from x in table1
                     join y in table2 on x.Hid equals y.Hid
                     where x.Hid == hid
                     select new LinqResult
                     {
                         Name = x.name,
                         Description = x.Description,
                         User = x.user
                     }).ToList();
         return list;
     }
