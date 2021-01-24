    var appointments = _sourceEntities.Appointments
                                      .Where(a => a.ApptDate.Year == currentDate.Year &&
                                                  a.ApptDate.Month == currentDate.Month &&
                                                  a.ApptDate.Day == currentDate.Date.Day)
                                      .Select(a => new { a,
                                                         AppEnd = a.ApptTime.AddMinutes(a.Duration)
                                                        })
                                      .ToList();
