            var m = typeof (AppChartGroup).GetProperties().ToList();
            List<object> charts= new List<Object>;
            m.ForEach(prop =>
            {
                if (prop.PropertyType.GetInterface(nameof(IEnumerable)) !=null)
                {
                    var chart= prop.GetValue(chartGroup) as IEnumerable<object>;               
                    charts.AddRange(data);
                }
            });
