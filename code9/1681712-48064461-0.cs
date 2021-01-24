    var theAs = new[]
    {
       new {A_ID = 547, ValueDate = new DateTime(2010, 05, 01), B_ID = 14750}, 
       new {A_ID = 547, ValueDate = new DateTime(2010, 10, 01), B_ID = 14751}
    };
    var theBs = new[]
    {
      new {B_ID = 14750, Status = "Foo"}, 
      new {B_ID = 14751, Status = "Bar"}
    };
    var listAffId = new[]{547};
    var query = (from tabA in (from a in theAs
                 where listAffId.Contains(a.A_ID)
                 // Order the data - the first row per group is thus max date
    			 orderby a.ValueDate descending
    	         group a by a.A_ID into grp
                 select new
                 {
                     pId = (int)grp.Key,
                     // Now pull the date and B_ID from the same row
                     valDate = grp.First().ValueDate,
                     bId = grp.First().B_ID
                 })
                 join tabB in theBs on tabA.bId equals tabB.B_ID
                 select new
                 {
                     affId = tabA.pId,
                     status = tabB.Status
                 });
