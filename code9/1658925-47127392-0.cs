                // Remove any events with blank first dose time if there is a duplicate that has
                // a valid first dose time
                var blanksToRemove        = new List<LogFileEvent>();
                var blankFirstDoseEvts    = AllEvents.Where(e => e.FirstDoseTime == PatientModel.DEFAULT_DATE)
                                                     .ToList();
                var nonBlankFirstDoseEvts = new HashSet<LogFileEvent>(AllEvents.Where(e => e.FirstDoseTime != PatientModel.DEFAULT_DATE),
                                                                      new BlankFirstDoseComparer());
                foreach (var blankEvt in blankFirstDoseEvts)
                {
                    if (nonBlankFirstDoseEvts.Contains(blankEvt))
                    {
                        blanksToRemove.Add(blankEvt);
                    }
                }
                AllEvents.RemoveAll(e => blanksToRemove.Contains(e));
