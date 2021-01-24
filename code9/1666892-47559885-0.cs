            void axisX_RangeChanged(LiveCharts.Events.RangeChangedEventArgs eventArgs)
        {
            double min = ((Axis)eventArgs.Axis).MinValue;
            double max = ((Axis)eventArgs.Axis).MaxValue;
            int p = 0;
            string name;
            foreach (Axis CartChart in FindVisualChildren<Axis>(TestGrid))
            {
                // do something with CartChart here
                name = CartChart.Name;
                if (name == "Y")
                {
                    continue;
                }
                else if (name == "X")
                {
                    CartChart.MinValue = min;
                    CartChart.MaxValue = max;
                }
                p++;
            }
        }
