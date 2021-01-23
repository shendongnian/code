            var q2 = Data.Where(b => b.GroupID != null).GroupBy((x) => x.GroupID).Select((y) => new
            {
                GroupID = y.First().ID,
                result = DynamicGroup(y)
            });
        private static string DynamicGroup(IGrouping<string,DataD> y)
        {
            string result=null;
            foreach (System.Reflection.PropertyInfo pInfo in typeof(DataD).GetProperties().Where(x=>x.Name!="GroupID" && x.Name!="ID"))
            {
                result += string.Format(" {0} ; ",string.Join(",", y.Select((k) => pInfo.GetValue(k, null)).Distinct()));
            }
            return result;
        }
