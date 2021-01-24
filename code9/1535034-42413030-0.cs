    //count column 'c' for each row
    var rowsWithCount = from t in db.table_1
                        select
                        new
                        {
                            t.RollNumber,
                            t.SubjectCode,
                            t.Status,
                            c = db.table_1.Count(i => i.RollNumber == t.RollNumber && i.SubjectCode == t.SubjectCode && i.Status != 0)
                        };
    
    //add condition for 'c'
    rowsWithCount = rowsWithCount.Where(i => i.c == 0);
    
    //group and order results
    var groupedResult = from r in rowsWithCount
                        group r by new { r.RollNumber, r.Status }
                        into g
                        orderby g.Key.RollNumber
                        select g;
