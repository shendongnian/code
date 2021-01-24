            for (int i = 0; i < 10; i++)
            {
                var series2 = new OxyPlot.Series.IntervalBarSeries { Title = "Series " + i.ToString(), StrokeThickness = 1 };
                model.Series.Add(series2);
                for (int j = 0; j < i; j++)
                    series2.Items.Add(new IntervalBarItem { CategoryIndex = j, Start = start2.AddHours(i).ToOADate(), End = end2.AddHours(i).ToOADate() });
            }
