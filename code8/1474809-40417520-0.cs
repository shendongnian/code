            foreach (DCHistory item in loadOperation.Entities.OrderByDescending(t => t.SensorNumber).Take(1))//Gets highest sensor number of the track
            {
                var sensor = item.SensorNumber + 1;//Gets the number we just asked from the loop. For example 8 or 12.
                var start = 1;
                var max = 12;
                while (start < sensor)
                {
                    var test = chart.Series.First(s => s.Name == string.Format("dsSensor{0}", start.ToString()));
                    test.Enabled = true;
                    start++;
                }
                if (sensor < max)
                {
                    while (sensor <= max)
                    {
                        var test2 = chart.Series.First(s => s.Name == string.Format("dsSensor{0}", sensor.ToString()));
                        test2.Enabled = false;
                        sensor++;
                    }
                }
            }
