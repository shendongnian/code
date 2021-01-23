    IQueryable<ResultClass> result=from t1 in db.Table1
                                     join t2 in db.Table2
                                     //Here the relation fields
                                     on t1.IdTable1 equals t2.IdTable2
                                     //Here where conditios and/or orderby
                                     select new ResultClass()
                                     {
                                         Field1=t1.SomeField,
                                         Field2=t2.SomeField,
                                         //all need fields
                                     }
