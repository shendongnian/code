    [Test]
        public void TemporaryDSTMuckaroundAdaptedTest()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timeZoneInfo in timeZones)
            {
                var name = timeZoneInfo.StandardName;
                foreach (var adjustmentRule in timeZoneInfo.GetAdjustmentRules())
                {
                    var startFixed = adjustmentRule.DaylightTransitionStart.IsFixedDateRule;
                    if (startFixed)
                    {
                        Console.WriteLine(name);
                        Console.WriteLine(adjustmentRule.DateStart);
                        var start = adjustmentRule.DaylightTransitionStart;
                        Assert.IsTrue(start.Month == 1);
                        Assert.IsTrue(start.Day == 1);
                        Assert.IsTrue(start.TimeOfDay.Hour == 0);
                    }
                    var endFixed = adjustmentRule.DaylightTransitionEnd.IsFixedDateRule;
                    if (!endFixed)
                        continue;
                    Console.WriteLine(adjustmentRule.DateEnd);
                    var end = adjustmentRule.DaylightTransitionEnd;
                    Assert.IsTrue(end.Month == 1);
                    Assert.IsTrue(end.Day == 1);
                    Assert.IsTrue(end.TimeOfDay.Hour == 0);
                }
            }
        }
