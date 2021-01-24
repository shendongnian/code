                chart.SetXAxis(new[]
                {
                    new XAxis { Categories = results.Date.ToArray()}
                });
                chart.SetSeries(
                    new Series
                    {
                        Data = new Data(results.Values.Cast<object>().ToArray())
                    }
                );
