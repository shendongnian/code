            var m = typeof (AppChartGroup).GetProperties().ToList();
            List<object> charts= new List<Object>;
            m.ForEach(prop =>
            {
                if (prop.PropertyType.IsSubclassOf(typeof(IEnumerable)))
                {
                    var chart= prop.GetValue(chartGroup) as List<object>;
                    charts.AddRange(data);
                }
            });
