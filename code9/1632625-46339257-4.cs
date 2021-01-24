        public static IQueryable<YourTable> GetFilteredQueryable(IQueryable<YourTable> yourTable)
        {
            // filter by time
            switch (RestoreLogic.WithinTimeBtnStatus)
            {
                case WithinTime.All:
                    break;
                case WithinTime.Hour:
                    DateTime offsetHour = DateTime.Now.Add(new TimeSpan(-1, 0, 0));
                    yourTable = yourTable.Where(e => e.Timestamp >= offsetHour);
                    break;
               // etc.
            }
            // filter by extension
            foreach (var i in FilteredExt)
            {
                yourTable = yourTable.Where(e => e.Ext != i);
            }
            // etc.
            return yourTable;
        }
