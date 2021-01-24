    var result = from item in list1.Concat(list2).Concat(list3)
                 group item.Rating by new { item.Empid, item.Empname } into g
                 select new {
                     Id = g.Empid,
                     Name = g.Empname,
                     Rating = g.Sum()
                 };
