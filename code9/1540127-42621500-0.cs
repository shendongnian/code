        DateTime d1 = new DateTime(2016, 11, 1);
            DateTime d2 = new DateTime(2016, 12, 1);
            var query = (from ent in query2
                         where
                             ent.PartitionKey == "ZIP"
                           && ent.RowKey.CompareTo(string.Format("{0:D19}", d1.Ticks)) > 0
                          && ent.RowKey.CompareTo(string.Format("{0:D19}", d2.Ticks)) < 0
                         select ent).Take(1).FirstOrDefault() ;
