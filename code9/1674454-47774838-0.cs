            //Returns "ABC > DateTime(2016,1,1,0,0,0) && ABC < DateTime(2018,1,1,0,0,0)"
            public static string BuildDateTimeListFilter(string filter,List<DateTime> dateTimeFilterList)
            {
                var filterDateTimeByString = dateTimeFilterList.Select(x => string.Format("DateTime({0},{1},{2},{3},{4},{5})", x.Year, x.Month, x.Day, x.Hour, x.Minute, x.Second)).ToArray();
                for (int i = 0; i < filterDateTimeByString.Length; i++)
                {
                    filter = filter.Replace("@" + i, filterDateTimeByString[i]);
                }
                return filter;
            }
