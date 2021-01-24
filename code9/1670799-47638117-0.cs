    dict = dt.Columns.Cast<DataColumn>()
        .ToDictionary(c => c.ColumnName, c =>
        {
            var dataSeries = new XyDataSeries<double, double>();
            double x = 1.0;
            dataSeries.Append(dt.AsEnumerable().Select(_ => x++), dt.AsEnumerable().Select(r => Convert.ToDouble(r[c])));
            return dataSeries;
        }).ToList();
