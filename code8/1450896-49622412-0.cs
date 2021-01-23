    var currentReadings = await Pedometer.GetSystemHistoryAsync(DateTime.Today);
                    var walklist = new List<PedometerReading>();
                    var runlist = new List<PedometerReading>();
                    foreach (var cuurentreading in currentReadings)
                    {
                        if (cuurentreading.StepKind == PedometerStepKind.Walking)
                        {
                            walklist.Add(cuurentreading);
                        }
                        if (cuurentreading.StepKind == PedometerStepKind.Running)
                        {
                            runlist.Add(cuurentreading);
                        }
                    }
                    var item = walklist.Last();
                    var item1 = walklist.First();
                    var item2 = runlist.Last();
                    var item3 = runlist.First();
                    Steps1.Value += (item.CumulativeSteps - item1.CumulativeSteps);
                    Steps1.Value += (item2.CumulativeSteps - item3.CumulativeSteps);
