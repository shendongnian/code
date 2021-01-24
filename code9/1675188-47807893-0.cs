        public class Table1
        {
            public string legacy, subid, converted, licPart;
            public int count;
        }
        public class Table2
        {
            public int ACCount, OBCount, OGCount;
            public string legacy;
        }
        private void JoinTables()
        {
            List<Table1> table1 = new List<Table1>();
            List<Table2> table2 = new List<Table2>();
            var result = from t1 in table1
                         join t2 in table2 on t1.legacy equals t2.legacy
                         select new Table1
                         {
                             legacy = t1.legacy,
                             converted = t1.converted,
                             licPart = t1.licPart,
                             subid = t1.subid,
                             count = t2.ACCount
                         };
        }
