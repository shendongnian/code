            for (int i = 0; i < 10; i++)
            {
                var series2 = new OxyPlot.Series.IntervalBarSeries { Title = "Series " + i.ToString(), StrokeThickness = 1 };
                series2.Items.Add(new IntervalBarItem { CategoryIndex = 0, Start = start2.AddHours(i).ToOADate(), End = end2.AddHours(i).ToOADate() });
                series2.Items.Add(new IntervalBarItem { CategoryIndex = 1, Start = start3.AddHours(i).ToOADate(), End = end3.AddHours(i).ToOADate() });
                model.Series.Add(series2);
            }
